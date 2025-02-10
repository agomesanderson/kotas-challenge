using Kotas.Pokemon.Domain.Commands.Input.Pokemons;
using Kotas.Pokemon.Domain.Commands.Output;
using Kotas.Pokemon.Domain.Commands.Output.Pokemons;
using Kotas.Pokemon.Domain.Entities;
using Kotas.Pokemon.Domain.Filters;
using Kotas.Pokemon.Domain.Repositories;
using Kotas.Pokemon.Infra.Common.Contracts;
using Kotas.Pokemon.Infra.Interfaces;
using Newtonsoft.Json;
using System.Text;

namespace Kotas.Pokemon.Domain.Handlers;

public class PokemonHandler
{
    private readonly IPokemonRepository _pokemonRepository;
    private readonly IPokemonService _pokemonService;

    public PokemonHandler(IPokemonRepository pokemonRepository, IPokemonService pokemonService)
    {
        _pokemonRepository = pokemonRepository;
        _pokemonService = pokemonService;
    }

    public async Task<ICommandResult> Handle(int id)
    {
        var pokemon = await _pokemonRepository.Get(id);
        var pokemonData = await GetPokemon(id);

        return new GenericCommandResult(true, "Pokemon carregado com sucesso", new { pokemon, pokemonData });
    }

    public async Task<ICommandResult> Handle()
    {
        var pokemons = await GetPokemonsRandom();

        return new GenericCommandResult(true, "Pokemon carregado com sucesso", new { pokemons });
    }

    public async Task<ICommandResult> Handle(PokemonFilter pokemonFilter)
    {
        var pokemons = await _pokemonRepository.GetAll(pokemonFilter);

        foreach (var pokemon in pokemons.Data)
        {
            var pokemonData = await GetPokemon(pokemon.Id);
            pokemon.Infos = pokemonData;
        }

        return new GenericCommandResult(true, "Pokemon carregado com sucesso", new { pokemons });
    }

    public async Task<ICommandResult> Handle(CreateCatchPokemonCommand command)
    {
        command.Validate();

        if (!command.IsValid)
            return new GenericCommandResult(false, "Pokemon inválido", command.Notifications);

        var pokemon = Entities.Pokemon.Create(command);

        var result = await _pokemonRepository.Insert(pokemon);

        return new GenericCommandResult(true, "Pokemon capturado cadastrado com sucesso", new { Id = result });
    }

    private async Task<List<PokemonResult>> GetPokemonsRandom()
    {
        var random = new Random();
        var randomNumbers = Enumerable.Range(1, 10).Select(_ => random.Next(1, 1000)).ToList();
        var pokemonsResults = new List<PokemonResult>();

        foreach (var id in randomNumbers)
        {
            PokemonResult result = await GetPokemon(id);

            pokemonsResults.Add(result);
        }

        return pokemonsResults;
    }

    private async Task<PokemonResult> GetPokemon(int id)
    {
        var pokemonData = await _pokemonService.GetPokemon(id);
        var evolutions = await _pokemonService.GetEvolutions(id);

        var result = new PokemonResult
        {
            Pokemon = pokemonData,
            Evolutions = evolutions,
            SpriteBase64 = Convert.ToBase64String(Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(pokemonData.Sprites)))
        };
        return result;
    }
}

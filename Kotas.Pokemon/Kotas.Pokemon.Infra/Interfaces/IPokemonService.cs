using Kotas.Pokemon.Infra.Dtos.Pokemons;

namespace Kotas.Pokemon.Infra.Interfaces;

public interface IPokemonService
{
    Task<PokemonDto> GetPokemon(int pokemon);
    Task<List<PokemonDto>> GetEvolutions(int pokemon);
}
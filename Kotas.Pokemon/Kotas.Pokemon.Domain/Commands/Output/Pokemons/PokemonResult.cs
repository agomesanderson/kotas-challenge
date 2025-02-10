using Kotas.Pokemon.Infra.Dtos.Pokemons;

namespace Kotas.Pokemon.Domain.Commands.Output.Pokemons;

public class PokemonResult
{
    public PokemonDto Pokemon { get; set; }
    public List<PokemonDto> Evolutions { get; set; }
    public string SpriteBase64 { get; set; }
}
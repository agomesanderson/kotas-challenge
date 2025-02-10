using Kotas.Pokemon.Domain.Commands.Output.Pokemons;

namespace Kotas.Pokemon.Domain.Queries;

public class PokemonQueryResult
{
    public int Id { get; set; }
    public int PokemonId { get; set; }
    public int PokeMasterId { get; set; }
    public PokemonResult Infos { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
}

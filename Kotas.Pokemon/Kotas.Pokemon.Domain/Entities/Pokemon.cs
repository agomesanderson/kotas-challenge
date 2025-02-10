using Kotas.Pokemon.Domain.Commands.Input.Pokemons;

namespace Kotas.Pokemon.Domain.Entities;

public class Pokemon
{
    #region Props

    public int Id { get; set; }
    public int PokemonId { get; set; }
    public int PokeMasterId { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }

    #endregion

    #region Constructors

    public Pokemon()
    {

    }

    #endregion

    #region Factories

    public static Pokemon Create(CreateCatchPokemonCommand command)
    {
        return new Pokemon
        {
            PokemonId = command.PokemonId,
            PokeMasterId = command.PokeMasterId,
            CreatedAt = DateTime.Now,
        };
    }

    #endregion
}

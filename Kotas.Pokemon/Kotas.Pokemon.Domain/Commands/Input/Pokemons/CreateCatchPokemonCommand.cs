using Flunt.Notifications;
using Flunt.Validations;

namespace Kotas.Pokemon.Domain.Commands.Input.Pokemons;

public class CreateCatchPokemonCommand : Notifiable<Notification>
{
    public int PokemonId { get; set; }
    public int PokeMasterId { get; set; }

    public void Validate()
    {
        AddNotifications(new Contract<CreateCatchPokemonCommand>()
            .IsGreaterThan(PokemonId, 0, "PokemonId precisa ser maior que zero")
            .IsGreaterThan(PokeMasterId, 0, "PokeMasterId precisa ser maior que zero")
        );
    }
}

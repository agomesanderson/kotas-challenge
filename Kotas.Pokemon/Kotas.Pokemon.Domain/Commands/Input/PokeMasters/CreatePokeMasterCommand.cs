using Flunt.Notifications;
using Flunt.Validations;

namespace Kotas.Pokemon.Domain.Commands.Input.PokeMasters;

public class CreatePokeMasterCommand : Notifiable<Notification>
{
    public string Name { get; set; }
    public int Age { get; set; }
    public string Document { get; set; }

    public void Validate()
    {
        AddNotifications(new Contract<CreatePokeMasterCommand>()
            .IsNotNullOrEmpty(Name, "Nome não pode ser vazio ou nulo")
            .IsGreaterThan(Age, 0, "Idade precisa ser maior que zero")
            .IsNotNullOrEmpty(Document, "Documento não pode ser vazio ou nulo")
        );
    }
}

using Kotas.Pokemon.Domain.Commands.Input.PokeMasters;

namespace Kotas.Pokemon.Domain.Entities;

public class PokeMaster
{
    #region Props

    public int Id { get; set; }
    public string Name { get; set; }
    public int Age { get; set; }
    public string Document { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }

    #endregion

    #region Constructors

    public PokeMaster()
    {

    }

    #endregion

    #region Factories

    public static PokeMaster Create(CreatePokeMasterCommand command)
    {
        return new PokeMaster
        {
            Name = command.Name,
            Age = command.Age,
            Document = command.Document,
            CreatedAt = DateTime.Now,
        };
    }

    #endregion
}

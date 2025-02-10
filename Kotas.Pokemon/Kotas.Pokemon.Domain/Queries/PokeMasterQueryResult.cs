namespace Kotas.Pokemon.Domain.Queries;

public class PokeMasterQueryResult
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int Age { get; set; }
    public string Document { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
}

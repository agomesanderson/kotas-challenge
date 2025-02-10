using Kotas.Pokemon.Domain.Queries.Common;

namespace Kotas.Pokemon.Domain.Queries;

public class PokemonPagedQueryResult
{
    public int Id { get; set; }
    public int PokemonId { get; set; }
    public int PokeMasterId { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
    public int TotalItems { get; set; }
    public int QuantityByPage { get; set; }

    public static PagedQueryResult<PokemonQueryResult> FillPaginated(IEnumerable<PokemonPagedQueryResult> items)
    {
        if (items is null || items.Count() == 0)
            return null!;

        var first = items.FirstOrDefault();

        return new PagedQueryResult<PokemonQueryResult>
        {
            TotalItems = first!.TotalItems,
            QuantityByPage = first.QuantityByPage,
            Data = items.Select(e => new PokemonQueryResult
            {
                Id = e.Id,
                PokemonId = e.PokemonId,
                PokeMasterId = e.PokeMasterId,
                CreatedAt = e.CreatedAt,
                UpdatedAt = e.UpdatedAt,
            })
        };
    }
}

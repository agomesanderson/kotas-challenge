using Kotas.Pokemon.Domain.Entities;
using Kotas.Pokemon.Domain.Filters;
using Kotas.Pokemon.Domain.Queries;
using Kotas.Pokemon.Domain.Queries.Common;

namespace Kotas.Pokemon.Domain.Repositories;

public interface IPokemonRepository
{
    Task<PokemonQueryResult> Get(int id);
    Task<PagedQueryResult<PokemonQueryResult>> GetAll(PokemonFilter filter);
    Task<int> Insert(Entities.Pokemon pokemon);
}

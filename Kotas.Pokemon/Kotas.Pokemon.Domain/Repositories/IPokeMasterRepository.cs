using Kotas.Pokemon.Domain.Queries;

namespace Kotas.Pokemon.Domain.Repositories;

public interface IPokeMasterRepository
{
    Task<PokeMasterQueryResult> Get(int id);
    Task<int> Insert(Entities.PokeMaster pokeMaster);
}

using Dapper;
using Kotas.Pokemon.Domain.Entities;
using Kotas.Pokemon.Domain.Filters;
using Kotas.Pokemon.Domain.Queries;
using Kotas.Pokemon.Domain.Queries.Common;
using Kotas.Pokemon.Domain.Repositories;
using Kotas.Pokemon.Infra.CrossCuttings.Configuration;
using Kotas.Pokemon.Infra.CrossCuttings.Factory;
using Kotas.Pokemon.Infra.Data.Queries;
using Microsoft.Extensions.Options;
using System.Data;

namespace Kotas.Pokemon.Infra.Data.Repositories;

public class PokemonRepository : IPokemonRepository
{
    public readonly AppConfigurations _settings;

    public PokemonRepository(IOptions<AppConfigurations> _options)
    {
        _settings = _options.Value;
    }

    public async Task<PokemonQueryResult> Get(int id)
    {
        try
        {
            var parameters = new DynamicParameters();
            parameters.Add("Id", id, DbType.Int32);

            using var connection = FactoryConnection.BuildConnection(_settings);
            return await connection.QueryFirstOrDefaultAsync<PokemonQueryResult>(PokemonQueries.Get, parameters);
        }
        catch (Exception ex)
        {
            throw;
        }
    }

    public async Task<PagedQueryResult<PokemonQueryResult>> GetAll(PokemonFilter filter)
    {
        try
        {
            var parameters = new DynamicParameters();
            parameters.Add("ActualPage", filter.ActualPage * filter.QuantityByPage);
            parameters.Add("QuantityByPage", filter.QuantityByPage);

            using var connection = FactoryConnection.BuildConnection(_settings);

            return PokemonPagedQueryResult.FillPaginated(
                await connection.QueryAsync<PokemonPagedQueryResult>(PokemonQueries.GetAll, parameters));
        }
        catch (Exception ex)
        {
            throw;
        }
    }

    public async Task<int> Insert(Domain.Entities.Pokemon pokemon)
    {
        var parameters = new DynamicParameters();
        parameters.Add("PokemonId", pokemon.PokemonId, DbType.Int32);
        parameters.Add("PokeMasterId", pokemon.PokeMasterId, DbType.Int32);
        parameters.Add("CreatedAt", pokemon.CreatedAt, DbType.DateTime);

        using var connection = FactoryConnection.BuildConnection(_settings);
        return await connection.QuerySingleAsync<int>(PokemonQueries.Insert, parameters);
    }
}

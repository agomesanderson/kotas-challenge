using Dapper;
using Kotas.Pokemon.Domain.Entities;
using Kotas.Pokemon.Domain.Queries;
using Kotas.Pokemon.Domain.Repositories;
using Kotas.Pokemon.Infra.CrossCuttings.Configuration;
using Kotas.Pokemon.Infra.CrossCuttings.Factory;
using Kotas.Pokemon.Infra.Data.Queries;
using Microsoft.Extensions.Options;
using System.Data;

namespace Kotas.Pokemon.Infra.Data.Repositories;

public class PokeMasterRepository : IPokeMasterRepository
{
    public readonly AppConfigurations _settings;

    public PokeMasterRepository(IOptions<AppConfigurations> _options)
    {
        _settings = _options.Value;
    }

    public async Task<PokeMasterQueryResult> Get(int id)
    {
        try
        {
            var parameters = new DynamicParameters();
            parameters.Add("Id", id, DbType.Int32);

            using var connection = FactoryConnection.BuildConnection(_settings);
            return await connection.QueryFirstOrDefaultAsync<PokeMasterQueryResult>(PokeMasterQueries.Get, parameters);
        }
        catch (Exception ex)
        {
            throw;
        }
    }

    public async Task<int> Insert(PokeMaster pokeMaster)
    {
        var parameters = new DynamicParameters();
        parameters.Add("Name", pokeMaster.Name, DbType.Int32);
        parameters.Add("Age", pokeMaster.Age, DbType.Int32);
        parameters.Add("Document", pokeMaster.Document, DbType.String);
        parameters.Add("CreatedAt", pokeMaster.CreatedAt, DbType.DateTime);

        using var connection = FactoryConnection.BuildConnection(_settings);
        return await connection.QuerySingleAsync<int>(PokeMasterQueries.Insert, parameters);
    }
}

using Kotas.Pokemon.Infra.CrossCuttings.Configuration;
using Microsoft.Data.Sqlite;

namespace Kotas.Pokemon.Infra.CrossCuttings.Factory
{
    public static class FactoryConnection
    {
        public static SqliteConnection BuildConnection(AppConfigurations settings)
        {
            return new SqliteConnection(settings.ConnectionString);
        }
    }
}

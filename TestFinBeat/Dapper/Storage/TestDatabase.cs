using Microsoft.Extensions.Options;
using TestFinBeat.Dapper.Config;
using Dapper;

namespace TestFinBeat.Dapper.Storage
{
    public class TestDatabase(IOptions<TestConfiguration> cfg) : TestStorage(cfg, true)
    {
        public void CreateDatabaseIfNotExists()
        {
            string nameDb = Config.Value.DbName;
            var query = $"SELECT datname FROM pg_database WHERE datname = '{nameDb}'";

            var records = connection.Query(query);
            if (!records.Any())
            {
                connection.Execute($"CREATE DATABASE {nameDb}");
            }
            else
            {
                connection.ChangeDatabase(nameDb);
            }
        }
    }
}

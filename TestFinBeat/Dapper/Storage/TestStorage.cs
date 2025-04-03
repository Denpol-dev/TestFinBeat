using Microsoft.Extensions.Options;
using Npgsql;
using TestFinBeat.Dapper.Config;

namespace TestFinBeat.Dapper.Storage
{
    public class TestStorage : IDisposable
    {
        protected readonly NpgsqlConnection connection;
        protected readonly IOptions<TestConfiguration> Config = null!;

        protected TestStorage(IOptions<TestConfiguration> cfg)
        {
            connection = new NpgsqlConnection(cfg.Value.ConnectionString);
        }

        protected TestStorage(IOptions<TestConfiguration> cfg, bool isServer)
        {
            string connectionString;
            Config = cfg;

            if (isServer)
            {
                connectionString = Config.Value.ConnectionStringDefaultDatabase;
            }
            else
            {
                connectionString = Config.Value.ConnectionString;
            }

            connection = new NpgsqlConnection(connectionString);
            connection.Open();
        }

        public async Task OpenConnectionAsync()
        {
            if (connection.State == System.Data.ConnectionState.Closed)
            {
                await connection.OpenAsync();
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                connection.Close();
            }
        }
    }
}

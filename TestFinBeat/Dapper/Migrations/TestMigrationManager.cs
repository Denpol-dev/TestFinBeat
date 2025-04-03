using FluentMigrator.Runner;
using TestFinBeat.Dapper.Storage;

namespace TestFinBeat.Dapper.Migrations
{
    public static class TestMigrationManager
    {
        public static IHost MigrationDatabase(this IHost host)
        {
            using (var scope = host.Services.CreateScope())
            {
                var databaseService = scope.ServiceProvider.GetRequiredService<TestDatabase>();
                var migrationService = scope.ServiceProvider.GetRequiredService<IMigrationRunner>();

                try
                {
                    databaseService.CreateDatabaseIfNotExists();

                    migrationService.ListMigrations();
                    migrationService.MigrateUp();
                }
                catch { }
            }

            return host;
        }
    }
}

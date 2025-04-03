using Microsoft.Extensions.Options;
using TestFinBeat.Dapper.Config;
using TestFinBeat.Dapper.Storage;
using FluentMigrator.Runner;
using System.Reflection;
using TestFinBeat.Services.Code;

namespace TestFinBeat.Registration
{
    public static class RegistrationExtension
    {
        public static IServiceCollection AddServices(this IServiceCollection services, IConfiguration configuration)
        {
            var cfg = new TestConfiguration();

            configuration
                .GetSection(TestConfiguration.DefaultSectionName)
                .Bind(cfg);
            services.AddSingleton(Options.Create(cfg));

            services.AddSingleton<TestDatabase>();
            services.AddLogging(c => c.AddFluentMigratorConsole())
                .AddFluentMigratorCore()
                .ConfigureRunner(c => c.AddPostgres11_0()
                    .WithGlobalConnectionString(cfg.ConnectionString)
                    .ScanIn(Assembly.GetExecutingAssembly()).For.Migrations());

            services.AddScoped<ICodeService, CodeService>();
            services.AddScoped<ICodeStorage, CodeStorage>();

            return services;
        }
    }
}

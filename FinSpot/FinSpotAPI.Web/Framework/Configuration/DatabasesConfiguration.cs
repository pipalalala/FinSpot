using Microsoft.EntityFrameworkCore;
using FinSpotAPI.Domain;
using FinSpotAPI.Common.Models.Options;
using FinSpotAPI.Infrastructure.Services.Interfaces;

namespace FinSpotAPI.Web.Framework.Configuration
{
    public static class DatabasesConfiguration
    {
        public static IServiceCollection ConfigureDatabases(
            this IServiceCollection services,
            IConfiguration configuration)
        {
            var secretsManager = services.BuildServiceProvider().GetService<ISecretsManager>();
            var databasesConnectionOptions = configuration
                .GetSection(DatabasesConnectionOptions.SectionPath)
                .Get<DatabasesConnectionOptions>();

            ArgumentNullException.ThrowIfNull(secretsManager, nameof(secretsManager));
            ArgumentNullException.ThrowIfNull(databasesConnectionOptions, nameof(databasesConnectionOptions));

            var finSpotPostgresConnectionString = secretsManager
                .GetSecretAsync(databasesConnectionOptions.FinSpotPostgresSecretName)
                .GetAwaiter()
                .GetResult();

            services.AddDbContext<FinSpotContext>(options =>
            {
                options.UseNpgsql(finSpotPostgresConnectionString, _ => _.MigrationsAssembly("FinSpotAPI.Domain.Migrations"));
                options.UseSnakeCaseNamingConvention();
            });

            return services;
        }
    }
}

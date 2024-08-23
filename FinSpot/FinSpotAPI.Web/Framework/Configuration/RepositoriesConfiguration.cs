using FinSpotAPI.Domain.Repositories;
using FinSpotAPI.Domain.Repositories.Interfaces;

namespace FinSpotAPI.Web.Framework.Configuration
{
    public static class RepositoriesConfiguration
    {
        public static IServiceCollection ConfigureRepositories(this IServiceCollection services)
        {
            services.AddTransient<IUsersRepository, UsersRepository>();
            services.AddTransient<IOperationsRepository, OperationsRepository>();

            return services;
        }
    }
}

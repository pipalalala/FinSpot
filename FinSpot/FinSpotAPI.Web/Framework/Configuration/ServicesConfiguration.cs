using FinSpotAPI.Application.Services;
using FinSpotAPI.Application.Services.Interfaces;
using FinSpotAPI.Infrastructure.Services;
using FinSpotAPI.Infrastructure.Services.Interfaces;

namespace FinSpotAPI.Web.Framework.Configuration
{
    public static class ServicesConfiguration
    {
        public static IServiceCollection ConfigureServices(this IServiceCollection services)
        {
            services.AddTransient<ISecretsManager, SecretsManager>();

            services.AddTransient<IPasswordHasher, PasswordHasher>();

            services.AddTransient<IUserService, UserService>();

            return services;
        }
    }
}

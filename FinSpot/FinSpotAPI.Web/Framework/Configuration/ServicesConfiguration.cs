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
            #region Infrastructure
            services.AddTransient<ISecretsManager, SecretsManager>();

            services.AddTransient<IPasswordHasher, PasswordHasher>();
            services.AddTransient<IJwtProvider, JwtProvider>();
            #endregion Infrastructure

            #region Application
            services.AddTransient<IUsersService, UsersService>();
            services.AddTransient<IOperationsService, OperationsService>();
            #endregion Application

            return services;
        }
    }
}

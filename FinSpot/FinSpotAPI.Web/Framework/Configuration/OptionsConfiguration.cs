using FinSpotAPI.Common.Models.Options;

namespace FinSpotAPI.Web.Framework.Configuration
{
    public static class OptionsConfiguration
    {
        public static IServiceCollection ConfigureOptions(
            this IServiceCollection services,
            IConfiguration configuration)
        {
            services.Configure<AuthenticationOptions>(configuration.GetSection(AuthenticationOptions.SectionPath));

            return services;
        }
    }
}

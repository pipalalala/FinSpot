namespace FinSpotAPI.Web.Framework.Configuration
{
    public static class AuthorizationConfiguration
    {
        public static IServiceCollection ConfigureAuthorization(this IServiceCollection services)
        {
            services.AddAuthorization();

            return services;
        }
    }
}

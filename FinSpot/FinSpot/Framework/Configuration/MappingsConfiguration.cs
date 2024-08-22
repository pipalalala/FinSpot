namespace FinSpotAPI.Web.Framework.Configuration
{
    public static class MappingsConfiguration
    {
        public static IServiceCollection ConfigureMappings(this IServiceCollection services)
        {
            services
                .AddAutoMapper(typeof(Mappings.V1.Users.UserMappingProfile).Assembly);

            return services;
        }
    }
}

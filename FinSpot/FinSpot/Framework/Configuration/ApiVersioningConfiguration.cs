namespace FinSpotAPI.Web.Framework.Configuration
{
    public static class ApiVersioningConfiguration
    {
        public static IServiceCollection ConfigureApiVersioning(this IServiceCollection services)
        {
            services
                .AddApiVersioning(_ =>
                {
                    _.ReportApiVersions = true;
                    _.AssumeDefaultVersionWhenUnspecified = true;
                    _.DefaultApiVersion = new Asp.Versioning.ApiVersion(1);
                })
                .AddApiExplorer(_ =>
                {
                    _.GroupNameFormat = "'v'VVV";
                    _.SubstituteApiVersionInUrl = true;
                });

            return services;
        }
    }
}

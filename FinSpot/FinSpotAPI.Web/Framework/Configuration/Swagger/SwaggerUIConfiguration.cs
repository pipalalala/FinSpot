using Asp.Versioning.ApiExplorer;

namespace FinSpotAPI.Web.Framework.Configuration.Swagger
{
    public static class SwaggerUIConfiguration
    {
        public static WebApplication ConfigureSwaggerUI(this WebApplication app)
        {
            app
                .UseSwagger()
                .UseSwaggerUI(_ =>
                {
                    foreach (var description in app.DescribeApiVersions())
                    {
                        string isDeprecated = description.IsDeprecated
                            ? " - deprecated"
                            : string.Empty;

                        _.SwaggerEndpoint(
                            $"/swagger/{description.GroupName}/swagger.json",
                            $"{description.GroupName.ToUpperInvariant()}{isDeprecated}");
                    }
                });

            return app;
        }
    }
}

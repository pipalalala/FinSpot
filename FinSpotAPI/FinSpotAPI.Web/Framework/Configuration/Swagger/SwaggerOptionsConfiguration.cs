using Microsoft.OpenApi.Models;
using Microsoft.Extensions.Options;
using Asp.Versioning.ApiExplorer;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace FinSpotAPI.Web.Framework.Configuration.Swagger
{
    public class SwaggerOptionsConfiguration : IConfigureNamedOptions<SwaggerGenOptions>
    {
        private readonly IApiVersionDescriptionProvider provider;

        public SwaggerOptionsConfiguration(IApiVersionDescriptionProvider provider)
        {
            this.provider = provider ?? throw new ArgumentNullException(nameof(provider));
        }

        public void Configure(string? name, SwaggerGenOptions options)
        {
            Configure(options);
        }

        public void Configure(SwaggerGenOptions options)
        {
            foreach (var description in provider.ApiVersionDescriptions)
            {
                options.SwaggerDoc(
                    description.GroupName,
                    CreateVersionInfo(description));
            }
        }

        private OpenApiInfo CreateVersionInfo(ApiVersionDescription description)
        {
            var info = new OpenApiInfo()
            {
                Title = "FinSpot API",
                Version = description.ApiVersion.ToString(),
                Contact = new OpenApiContact
                {
                    Email = "raman.zinevich.111@gmail.com",
                    Name = "FinSpot"
                },
                Description = "FinSpot API provides information about user finance operations."
            };

            if (description.IsDeprecated)
            {
                info.Description += " This API version has been deprecated.";
            }

            return info;
        }
    }
}

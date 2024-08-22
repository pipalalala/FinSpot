using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Net.Http.Headers;
using Microsoft.OpenApi.Models;

namespace FinSpotAPI.Web.Framework.Configuration.Swagger
{
    public static class SwaggerConfiguration
    {
        public static IServiceCollection ConfigureSwagger(this IServiceCollection services)
        {
            services
                .AddSwaggerGen(_ =>
                {
                    _.OperationFilter<DeprecatedFilter>();
                    _.AddSecurityDefinition(
                        JwtBearerDefaults.AuthenticationScheme,
                        new OpenApiSecurityScheme
                        {
                            In = ParameterLocation.Header,
                            Description = "Enter the Bearer Authorization string",
                            Name = HeaderNames.Authorization,
                            Type = SecuritySchemeType.Http,
                            Scheme = JwtBearerDefaults.AuthenticationScheme
                        });
                    _.AddSecurityRequirement(
                        new OpenApiSecurityRequirement
                        {
                            {
                                new OpenApiSecurityScheme
                                {
                                    Name = JwtBearerDefaults.AuthenticationScheme,
                                    In = ParameterLocation.Header,
                                    Reference = new OpenApiReference
                                    {
                                        Type=ReferenceType.SecurityScheme,
                                        Id = JwtBearerDefaults.AuthenticationScheme
                                    }
                                },
                                new List<string>{}
                            }
                        });
                })
                .ConfigureOptions<SwaggerOptionsConfiguration>();

            return services;
        }
    }
}

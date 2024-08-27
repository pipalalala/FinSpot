using System.Text;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using FinSpotAPI.Common.Models.Options;
using FinSpotAPI.Infrastructure.Services.Interfaces;

namespace FinSpotAPI.Web.Framework.Configuration
{
    public static class AuthenticationConfiguration
    {
        public static IServiceCollection ConfigureAuthentication(
            this IServiceCollection services,
            IConfiguration configuration)
        {
            var secretsManager = services.BuildServiceProvider().GetService<ISecretsManager>();
            var authenticationOptions = configuration
                .GetSection(AuthenticationOptions.SectionPath)
                .Get<AuthenticationOptions>();

            ArgumentNullException.ThrowIfNull(secretsManager, nameof(secretsManager));
            ArgumentNullException.ThrowIfNull(authenticationOptions, nameof(authenticationOptions));

            var issuerSigningKey = secretsManager
                .GetSecretAsync(authenticationOptions.IssuerSigningKeySecretName)
                .GetAwaiter()
                .GetResult();

            services
                .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(_ =>
                {
                    _.TokenValidationParameters = new TokenValidationParameters
                    {
                        // set clockskew to zero so tokens expire exactly at token expiration time (instead of 5 minutes later)
                        ClockSkew = TimeSpan.Zero,
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        ValidIssuer = authenticationOptions.Issuer,
                        ValidAudience = authenticationOptions.Audience,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(issuerSigningKey!))
                    };
                });

            return services;
        }
    }
}

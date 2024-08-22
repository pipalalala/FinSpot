using System.Reflection;
using FluentValidation;
using FluentValidation.AspNetCore;

namespace FinSpotAPI.Web.Framework.Configuration
{
    public static class ValidationConfiguration
    {
        public static IServiceCollection ConfigureValidation(this IServiceCollection services)
        {
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            services.AddFluentValidationAutoValidation();

            return services;
        }
    }
}

using Microsoft.OpenApi.Models;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace FinSpotAPI.Web.Framework.Configuration.Swagger
{
    public class DeprecatedFilter : IOperationFilter
    {
        public void Apply(OpenApiOperation operation, OperationFilterContext context)
        {
            var apiDescription = context.ApiDescription;

            if (apiDescription.IsDeprecated())
            {
                operation.Deprecated = true;
            }
        }
    }
}

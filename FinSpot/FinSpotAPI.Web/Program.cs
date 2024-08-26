using FinSpotAPI.Web.Framework.Configuration;
using FinSpotAPI.Web.Framework.Configuration.Swagger;
using FinSpotAPI.Web.Framework.Middlewares;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);
var services = builder.Services;
var configuration = builder.Configuration;

services
    .ConfigureOptions(configuration)
    .ConfigureMappings()
    .ConfigureServices()
    .ConfigureRepositories()
    .ConfigureDatabases(configuration);

services
    .ConfigureApiVersioning()
    .AddEndpointsApiExplorer()
    .ConfigureSwagger()
    .ConfigureValidation()
    .AddHttpContextAccessor();

services
    .ConfigureAuthentication(configuration)
    .ConfigureAuthorization();

services
    .AddControllers()
    .AddJsonOptions(_ =>
    {
        _.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
    });

var app = builder.Build();

app.ConfigureSwaggerUI();

app.UseHttpsRedirection();

app.UseMiddleware<ErrorHandlingMiddleware>();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();

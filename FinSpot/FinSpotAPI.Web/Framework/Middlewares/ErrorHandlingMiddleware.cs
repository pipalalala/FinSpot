using System.Net;
using FinSpotAPI.Common.Models;
using FinSpotAPI.Common.Exceptions;

namespace FinSpotAPI.Web.Framework.Middlewares
{
    public class ErrorHandlingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ErrorHandlingMiddleware> _logger;

        public ErrorHandlingMiddleware(
            RequestDelegate next,
            ILogger<ErrorHandlingMiddleware> logger)
        {
            _next = next ?? throw new ArgumentNullException(nameof(next));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);

                await HandleExceptionAsync(context, ex);
            }
        }

        private static async Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            context.Response.ContentType = "application/json";

            switch (exception)
            {
                case ConflictException:
                    {
                        context.Response.StatusCode = (int)HttpStatusCode.Conflict;
                        break;
                    }
                case NotFoundException:
                    {
                        context.Response.StatusCode = (int)HttpStatusCode.NotFound;
                        break;
                    }
                case AuthenticationException:
                    {
                        context.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
                        break;
                    }
                default:
                    {
                        context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                        await context.Response.WriteAsJsonAsync(CreateResponse("Internal Server Error.", exception.Message));
                        break;
                    }
            }

            if (exception is BaseApplicationException)
            {
                var baseApplicationException = exception as BaseApplicationException;

                await context.Response.WriteAsJsonAsync(CreateResponse(
                    baseApplicationException!.Message,
                    baseApplicationException!.Details));
            }

            return;
        }

        private static ErrorResponseModel CreateResponse(string message, string? details = null)
        {
            return new ErrorResponseModel
            {
                Message = message,
                Details = details
            };
        }
    }
}

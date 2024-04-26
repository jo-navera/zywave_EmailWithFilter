using Microsoft.AspNetCore.Diagnostics;
using System.Diagnostics;

namespace ZywaveApi
{
    public class GlobalExceptionHandler(ILogger<GlobalExceptionHandler> logger) : IExceptionHandler
    {
        private readonly ILogger<GlobalExceptionHandler> _logger = logger;

        public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
        {
            var traceId = Activity.Current?.Id ?? httpContext.TraceIdentifier;
            _logger.LogError(
                exception,
                $"Unable to process the request. Please reach out to account@gmail.com with TraceId: {traceId}"
                );

            var (statusCode, title) = MapException(exception);

            await Results.Problem(title: title,
                statusCode: statusCode,
                extensions: new Dictionary<string, object?>
                {
                    {"traceId", traceId }
                }).ExecuteAsync(httpContext);

            return true;
        }

        private static (int statusCode, string title) MapException(Exception exception)
        {
            return exception switch {
                ArgumentNullException => (StatusCodes.Status400BadRequest, exception.Message),
                _ => (StatusCodes.Status500InternalServerError, Constants.GenericExceptionMessage)
            };
        }
    }
}

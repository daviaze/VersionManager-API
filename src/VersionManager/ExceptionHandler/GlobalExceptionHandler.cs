using Microsoft.AspNetCore.Diagnostics;
using Microsoft.EntityFrameworkCore;
using VersionManager.Domain.Exceptions;

namespace VersionManager.ExceptionHandler
{
    public sealed class GlobalExceptionHandler(Serilog.ILogger logger) : IExceptionHandler
    {
        private readonly Serilog.ILogger _logger = logger;
        public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
        {
            var result = exception switch
            {
                DomainOperationException => StatusCodes.Status400BadRequest,
                DbUpdateException => StatusCodes.Status400BadRequest,
                _ => StatusCodes.Status500InternalServerError,
            };

            httpContext.Response.StatusCode = result;
            httpContext.Response.ContentType = "application/json";

            if (exception is not
                DomainOperationException) _logger.Error(exception,
                    "Exception caught in the GlobalExceptionHandler...");

            var message = exception.InnerException?.Message ?? exception.Message;

            await httpContext.Response.WriteAsJsonAsync(message, cancellationToken);

            return true;
        }
    }
}

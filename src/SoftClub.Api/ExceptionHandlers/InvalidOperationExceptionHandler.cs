using Microsoft.AspNetCore.Diagnostics;
using Microsoft.Extensions.Logging;
using SoftClub.Api.Models;
using System.Net;

namespace SoftClub.Api.ExceptionHandlers;

public class InvalidOperationExceptionHandler(ILogger<InvalidOperationExceptionHandler> logger) : IExceptionHandler
{
    public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
    {
        if (exception is not InvalidOperationException)
            return false;

        httpContext.Response.StatusCode = (int)HttpStatusCode.NotFound;
        httpContext.Response.ContentType = "application/json";

        var response = new ApiErrorResponse
        {
            Code = (int)HttpStatusCode.NotFound,
            Message = exception.Message,
        };

        await httpContext.Response.WriteAsJsonAsync(response, cancellationToken);

        logger.LogError(exception.Message);

        return true;
    }
}
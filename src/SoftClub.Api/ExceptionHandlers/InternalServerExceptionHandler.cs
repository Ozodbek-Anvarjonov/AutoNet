using Microsoft.AspNetCore.Diagnostics;
using SoftClub.Api.Models;
using System.Net;

namespace SoftClub.Api.ExceptionHandlers;

public class InternalServerExceptionHandler(ILogger<InternalServerExceptionHandler> logger) : IExceptionHandler
{
    public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
    {
        httpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
        httpContext.Response.ContentType = "application/json";

        var response = new ApiErrorResponse
        {
            Code = (int)HttpStatusCode.InternalServerError,
            Message = exception.Message,
        };

        await httpContext.Response.WriteAsJsonAsync(response, cancellationToken);

        logger.LogError(exception.Message);

        return true;
    }
}
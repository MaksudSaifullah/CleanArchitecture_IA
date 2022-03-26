using Internal.Audit.Application.Common;
using System.Diagnostics;
using System.Net;

namespace Internal.Audit.Api.Middlewares;

public class ExceptionLoggingMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<ApplicationLog> _logger;

    public ExceptionLoggingMiddleware(RequestDelegate next, ILogger<ApplicationLog> logger)
    {
        _next = next;
        this._logger = logger;
    }
    public async Task InvokeAsync(HttpContext httpContext)
    {
        try
        {
            await _next(httpContext);
        }
        catch (Exception ex)
        {
            LogException(ex);
            await HandleException(httpContext);
        }
    }
    private void LogException(Exception exception)
    {
        var strackTrace = new StackTrace(exception);
        _logger.LogError((strackTrace?.GetFrame(0)?.GetMethod()?.DeclaringType) + " " + (strackTrace?.GetFrame(0)?.GetMethod()?.Name ?? "") +
            ": Something went wrong: " + exception.Message);
    }

    private async Task HandleException(HttpContext context)
    {
        context.Response.ContentType = "application/json";
        context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
        await context.Response.WriteAsync(new BaseResponseDTO
        (
            0,
            false,
            "Something went wrong. Please contact administrator"
        ).ToString());
    }
}

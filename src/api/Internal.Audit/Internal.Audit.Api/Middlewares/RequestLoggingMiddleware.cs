using System.Security.Claims;

namespace Internal.Audit.Api.Middlewares;

public class RequestLoggingMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<ApplicationLog> _logger;
    private readonly IConfiguration _configuration;

    public RequestLoggingMiddleware(RequestDelegate next, ILogger<ApplicationLog> logger, IConfiguration configuration)
    {
        _next = next;
        _logger = logger;
        _configuration = configuration;
    }
    public async Task InvokeAsync(HttpContext httpContext)
    {
        try
        {
            await _next(httpContext);
        }
        finally
        {
            bool logRequest;
            var userIdentity = httpContext.User.Claims.Where(x => x.Type == ClaimTypes.NameIdentifier).FirstOrDefault();
            if(bool.TryParse(_configuration["CustomLog:LogRequest"], out logRequest) && logRequest)
                _logger.LogInformation("Request {method} {url} => {statusCode} => Requested By: {user}",
                    httpContext.Request?.Method,
                    httpContext.Request?.Path.Value,
                    httpContext.Response?.StatusCode,
                    (userIdentity?.Value ?? ""));
        }
    }
}

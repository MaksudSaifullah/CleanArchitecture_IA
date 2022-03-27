
using MediatR;
using System.Diagnostics;
using Serilog;
using Microsoft.Extensions.Logging;
using Internal.Audit.Application.Contracts.Auth;
using Microsoft.Extensions.Configuration;

namespace Internal.Audit.Application.Behaviours;

public class PerformanceLoggingBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : IRequest<TResponse>
{
    private readonly Stopwatch _timer;
    private readonly IConfiguration _configuration;
    private readonly ILogger<TRequest> _logger;
    private readonly ICurrentAuthService _currentAuthService;

    public PerformanceLoggingBehaviour(IConfiguration configuration, ILogger<TRequest> logger, ICurrentAuthService currentAuthService)
    {
        _timer = new Stopwatch();
        _configuration = configuration;
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        _currentAuthService = currentAuthService ?? throw new ArgumentNullException(nameof(currentAuthService));
    }

    public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
    {
        bool logPerformance;
        if (!bool.TryParse(_configuration["CustomLog:LogPeformance"], out logPerformance) || !logPerformance)
            return await next();

        _timer.Start();

        var response = await next();

        _timer.Stop();

        var elapsedMilliseconds = _timer.ElapsedMilliseconds;
        long timeThreshold;
        timeThreshold = long.TryParse(_configuration["CustomLog:RequestElapsedThresholdTimeInMilliseconds"], out timeThreshold) 
            ? timeThreshold : long.MaxValue;

        if (elapsedMilliseconds > timeThreshold)
        {
            var requestName = typeof(TRequest).Name;
            var email = _currentAuthService.Email ?? string.Empty;

            _logger.LogWarning("CleanArchitecture Long Running Request: {Name} ({ElapsedMilliseconds} milliseconds) {@UserId} {@Request}",
                requestName, elapsedMilliseconds, email, request);
        }

        return response;
    }
}

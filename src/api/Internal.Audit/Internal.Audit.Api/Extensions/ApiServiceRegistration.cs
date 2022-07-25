using Internal.Audit.Api.Services;
using Internal.Audit.Application.Contracts.Auth;

namespace Internal.Audit.Api.Extensions;

public static class ApiServiceRegistration
{
    public static IServiceCollection AddApiServices(this IServiceCollection services)
    {
        services.AddTransient<ICurrentAuthService, CurrentAuthService>();
        services.AddTransient<IJwtTokenService, JwtTokenService>();
        services.AddTransient<IGoogleRecatchaVerificationService, GoogleRecatchaVerificationService>();

        return services;
    }
}

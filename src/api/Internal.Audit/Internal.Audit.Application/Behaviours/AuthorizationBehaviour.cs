
using Internal.Audit.Application.Common.Security;
using Internal.Audit.Application.Contracts.Auth;
using MediatR;
using System.Reflection;

namespace Internal.Audit.Application.Behaviours;

public class AuthorizationBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : IRequest<TResponse>
{
    private readonly ICurrentAuthService _currentAuthService;

    public AuthorizationBehaviour(ICurrentAuthService currentAuthService)
    {
        _currentAuthService = currentAuthService ?? throw new ArgumentNullException(nameof(currentAuthService));
    }

    public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
    {
        var authorizeAttributes = request.GetType().GetCustomAttributes<AuthorizeAttribute>();

        if (authorizeAttributes.Any())
        {
            if (string.IsNullOrEmpty(_currentAuthService.Email))
                throw new UnauthorizedAccessException();

            var roles = authorizeAttributes.SelectMany(a => a.Roles.Split(',')).ToList();

            if (roles.Any())
            {
                var authorize = false;
                foreach (var role in roles)
                {
                    if (role.Equals("ADMIN")) //TODO: need to check roles from DB
                    {
                        authorize = true;
                        break;
                    }
                }

                if(!authorize)
                    throw new UnauthorizedAccessException();
            }

        }

        return await next();
    }
}

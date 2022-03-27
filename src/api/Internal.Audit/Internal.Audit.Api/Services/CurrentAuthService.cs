using Internal.Audit.Application.Contracts.Auth;
using System.Security.Claims;

namespace Internal.Audit.Api.Services
{
    public class CurrentAuthService : ICurrentAuthService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public CurrentAuthService(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor ?? throw new ArgumentNullException(nameof(httpContextAccessor));
        }

        public string? UserId => _httpContextAccessor.HttpContext?.User?.FindFirstValue(ClaimTypes.NameIdentifier);
    }
}

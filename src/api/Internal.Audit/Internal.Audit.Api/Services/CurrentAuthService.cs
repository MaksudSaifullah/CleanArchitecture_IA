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

        public string? Email => _httpContextAccessor.HttpContext?.User?.FindFirstValue(ClaimTypes.Email) ?? "admin.ia@asa-international.com"; // TODO: will be removed later
    }
}

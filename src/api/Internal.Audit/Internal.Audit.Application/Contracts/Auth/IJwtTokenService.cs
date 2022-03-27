
namespace Internal.Audit.Application.Contracts.Auth;

public interface IJwtTokenService
{
    string GenerateJwtToken(string email, string name);
}

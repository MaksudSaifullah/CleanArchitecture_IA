
namespace Internal.Audit.Application.Features.Users.Queries.GetAuthUser;

public class AuthUserDTO
{
    public bool Success { get; set; }
    public string Name { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string Token { get; set; } = null!;
    public string Role { get; set; } = null!;
}

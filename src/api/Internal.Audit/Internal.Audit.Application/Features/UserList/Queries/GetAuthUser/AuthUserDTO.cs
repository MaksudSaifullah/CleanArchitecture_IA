
namespace Internal.Audit.Application.Features.UserList.Queries.GetAuthUser;

 public class AuthUserDTO
{
    public bool Success { get; set; }
    public string Name { get; set; } = null!;
    public string UserName { get; set; } = null!;
    public string Token { get; set; } = null!;
    public string Role { get; set; } = null!;
}

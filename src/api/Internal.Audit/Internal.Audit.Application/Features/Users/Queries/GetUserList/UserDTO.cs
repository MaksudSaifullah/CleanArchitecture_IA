
namespace Internal.Audit.Application.Features.Users.Queries.GetUserList;

public record UserDTO
{
    public long Id { get; set; }
    public string Email { get; set; } = null!;
    public string Password { get; set; } = null!;
    public bool Status { get; set; }
    public bool LoginStatus { get; set; }
    public DateTime? LastLoginTime { get; set; }
}

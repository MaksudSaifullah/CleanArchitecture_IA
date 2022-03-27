
using Internal.Audit.Application.Common.Security;
using MediatR;

namespace Internal.Audit.Application.Features.Users.Commands.AddUser;

[Authorize(Roles = "ADMIN")]
public class AddUserCommand: IRequest<AddUserResponseDTO>
{
    public long Id { get; set; }
    public string Email { get; set; } = null!;
    public string Password { get; set; } = null!;
    public bool Status { get; set; }
    public bool LoginStatus { get; set; }
    public DateTime? LastLoginTime { get; set; }
}

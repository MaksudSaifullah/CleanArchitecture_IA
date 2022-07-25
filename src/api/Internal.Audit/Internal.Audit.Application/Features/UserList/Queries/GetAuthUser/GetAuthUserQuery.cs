
using MediatR;

namespace Internal.Audit.Application.Features.UserList.Queries.GetAuthUser;
public class GetAuthUserQuery: IRequest<AuthUserDTO>
{
    public string Email { get; set; } = null!;
    public string Password { get; set; } = null!;
    public string? CaptchaToken { get; set; }
}

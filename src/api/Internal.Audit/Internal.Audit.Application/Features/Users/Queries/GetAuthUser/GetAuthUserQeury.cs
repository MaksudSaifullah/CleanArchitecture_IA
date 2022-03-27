
using MediatR;

namespace Internal.Audit.Application.Features.Users.Queries.GetAuthUser;

public class GetAuthUserQeury: IRequest<AuthUserDTO>
{
    public string Email { get; set; } = null!;
    public string Password { get; set; } = null!;
}

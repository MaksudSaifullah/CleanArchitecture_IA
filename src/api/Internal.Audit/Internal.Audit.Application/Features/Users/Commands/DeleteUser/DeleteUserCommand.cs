
using Internal.Audit.Application.Common.Security;
using MediatR;

namespace Internal.Audit.Application.Features.Users.Commands.DeleteUser;

[Authorize(Roles = "ADMIN")]
public class DeleteUserCommand : IRequest<DeleteUserResponseDTO>
{
    public Guid Id { get; set; }

    public DeleteUserCommand(Guid id)
    {
        Id = id;
    }
}

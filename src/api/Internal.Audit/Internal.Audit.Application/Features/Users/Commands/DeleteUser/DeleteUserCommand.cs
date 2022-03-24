
using MediatR;

namespace Internal.Audit.Application.Features.Users.Commands.DeleteUser;

public class DeleteUserCommand : IRequest<DeleteUserResponseDTO>
{
    public long Id { get; set; }

    public DeleteUserCommand(long id)
    {
        Id = id;
    }
}

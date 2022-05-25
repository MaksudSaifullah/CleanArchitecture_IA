
using Internal.Audit.Application.Common;

namespace Internal.Audit.Application.Features.Users.Commands.DeleteUser;

public record DeleteUserResponseDTO : BaseResponseDTO
{
    public DeleteUserResponseDTO(Guid Id, bool Success, string Message) : base(Id, Success, Message)
    {
    }
}

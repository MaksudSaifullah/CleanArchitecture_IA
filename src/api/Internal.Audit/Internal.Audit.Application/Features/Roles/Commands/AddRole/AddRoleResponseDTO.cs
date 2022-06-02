using Internal.Audit.Application.Common;

namespace Internal.Audit.Application.Features.Roles.Commands.AddRole;

public record AddRoleResponseDTO : BaseResponseDTO
{
    public AddRoleResponseDTO(Guid Id, bool Success, string Message) : base(Id, Success, Message)
    {
    }
}
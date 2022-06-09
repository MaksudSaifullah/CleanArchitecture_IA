using Internal.Audit.Application.Common;

namespace Internal.Audit.Application.Features.AccessPrivilege.Commands.UpdateAccessPrivilege;
public record UpdateAccessPrivilegeResponseDTO : BaseResponseDTO
{
    public UpdateAccessPrivilegeResponseDTO(Guid Id, bool Success, string Message) : base(Id, Success, Message)
    {
    }
}
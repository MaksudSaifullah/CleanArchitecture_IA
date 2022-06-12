using Internal.Audit.Application.Common;

namespace Internal.Audit.Application.Features.AccessPrivilege.Commands.AddAccessPrivilege;
public record AddAccessPrivilegeResponseDTO : BaseResponseDTO
{
    public AddAccessPrivilegeResponseDTO(Guid Id, bool Success, string Message) : base(Id, Success, Message)
    {
    }
}
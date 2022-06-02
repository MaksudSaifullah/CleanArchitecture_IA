using Internal.Audit.Application.Common;

namespace Internal.Audit.Application.Features.Designation.Commands.UpdateDesignation;
public record UpdateDesignationResponseDTO : BaseResponseDTO
{
    public UpdateDesignationResponseDTO(Guid Id, bool Success, string Message) : base(Id, Success, Message)
    {
    }
}

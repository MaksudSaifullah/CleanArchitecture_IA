using Internal.Audit.Application.Common;

namespace Internal.Audit.Application.Features.Designation.Commands.DeleteDesignation;
public record DeleteDesignationResponseDTO : BaseResponseDTO
{
    public DeleteDesignationResponseDTO(Guid Id, bool Success, string Message) : base(Id, Success, Message)
    {
    }
}

using Internal.Audit.Application.Common;

namespace Internal.Audit.Application.Features.Designation.Commands.AddDesignation;

public record AddDesignationResponseDTO : BaseResponseDTO
{
    public AddDesignationResponseDTO(Guid Id, bool Success, string Message) : base(Id, Success, Message)
    {
    }
}

using Internal.Audit.Application.Common;

namespace Internal.Audit.Application.Features.IssueValidations.Commands.DeleteIssueValidationCommand;

public record DeleteIssueValidationCommandResponseDTO : BaseResponseDTO
{
    public DeleteIssueValidationCommandResponseDTO(Guid Id, bool Success, string Message) : base(Id, Success, Message)
    {
    }
}


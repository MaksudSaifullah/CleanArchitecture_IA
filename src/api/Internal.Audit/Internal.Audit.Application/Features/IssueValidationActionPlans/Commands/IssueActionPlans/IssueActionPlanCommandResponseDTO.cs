using Internal.Audit.Application.Common;

namespace Internal.Audit.Application.Features.IssueValidationActionPlans.Commands.IssueActionPlans;

public record IssueActionPlanCommandResponseDTO : BaseResponseDTO
{
    public IssueActionPlanCommandResponseDTO(Guid Id, bool Success, string Message) : base(Id, Success, Message)
    {
    }
}


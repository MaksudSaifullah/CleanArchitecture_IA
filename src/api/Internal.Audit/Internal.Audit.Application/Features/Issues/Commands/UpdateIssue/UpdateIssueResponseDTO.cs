using Internal.Audit.Application.Common;


namespace Internal.Audit.Application.Features.Issues.Commands.UpdateIssue;
public record UpdateIssueResponseDTO : BaseResponseDTO
{
    public UpdateIssueResponseDTO(Guid Id, bool Success, string Message) : base(Id, Success, Message)
    {
    }
}

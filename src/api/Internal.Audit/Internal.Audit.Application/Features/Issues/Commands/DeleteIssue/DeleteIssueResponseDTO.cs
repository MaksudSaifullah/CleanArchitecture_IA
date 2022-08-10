using Internal.Audit.Application.Common;


namespace Internal.Audit.Application.Features.Issues.Commands.DeleteIssue;
public record DeleteIssueResponseDTO : BaseResponseDTO
{
    public DeleteIssueResponseDTO(Guid Id, bool Success, string Message) : base(Id, Success, Message)
    {
    }
}
using Internal.Audit.Application.Common;


namespace Internal.Audit.Application.Features.Issues.Commands.AddIssue;
public record AddIssueResponseDTO : BaseResponseDTO
{
    public AddIssueResponseDTO(Guid Id, bool Success, string Message) : base(Id, Success, Message)
    {
    }
}
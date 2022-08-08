using MediatR;


namespace Internal.Audit.Application.Features.Issues.Commands.DeleteIssue;
public class DeleteIssueCommand : IRequest<DeleteIssueResponseDTO>
{
    public Guid Id { get; set; }
    public DeleteIssueCommand(Guid id)
    {
        Id = id;
    }
}

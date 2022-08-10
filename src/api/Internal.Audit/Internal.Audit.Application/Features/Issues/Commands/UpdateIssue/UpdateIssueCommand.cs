using MediatR;

namespace Internal.Audit.Application.Features.Issues.Commands.UpdateIssue;

public class UpdateIssueCommand : IRequest<UpdateIssueResponseDTO>
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string? Description { get; set; } = null;
    public DateTime EffectiveFrom { get; set; }
    public DateTime EffectiveTo { get; set; }
}


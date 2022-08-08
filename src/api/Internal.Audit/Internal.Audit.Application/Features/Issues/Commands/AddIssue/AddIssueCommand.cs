using MediatR;

namespace Internal.Audit.Application.Features.Issues.Commands.AddIssue;
public class AddIssueCommand : IRequest<AddIssueResponseDTO>
{
    public string Name { get; set; }
    public string? Description { get; set; } = null;
    public DateTime EffectiveFrom { get; set; }
    public DateTime EffectiveTo { get; set; }
}

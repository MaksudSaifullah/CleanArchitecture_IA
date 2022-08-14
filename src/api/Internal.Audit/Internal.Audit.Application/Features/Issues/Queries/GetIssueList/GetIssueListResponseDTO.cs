
namespace Internal.Audit.Application.Features.Issues.Queries.GetIssueList;
public record GetIssueListResponseDTO
{
    public Guid Id { get; set; }
    public DateTime EffectiveFrom { get; set; }
    public DateTime EffectiveTo { get; set; }
    public string Description { get; set; } = null!;
}

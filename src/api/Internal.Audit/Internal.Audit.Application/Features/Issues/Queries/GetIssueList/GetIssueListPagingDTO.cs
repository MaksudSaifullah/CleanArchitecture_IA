
namespace Internal.Audit.Application.Features.Issues.Queries.GetIssueList;
public record GetIssueListPagingDTO
{
    public IEnumerable<GetIssueListResponseDTO> Items { get; set; } = null!;
    public long TotalCount { get; set; }
}
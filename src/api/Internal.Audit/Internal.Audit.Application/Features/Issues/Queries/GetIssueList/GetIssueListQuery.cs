using MediatR;

namespace Internal.Audit.Application.Features.Issues.Queries.GetIssueList;
public class GetIssueListQuery : IRequest<GetIssueListPagingDTO>
{
    public int pageSize { get; set; }
    public int pageNumber { get; set; }
    public dynamic searchTerm { get; set; }
}
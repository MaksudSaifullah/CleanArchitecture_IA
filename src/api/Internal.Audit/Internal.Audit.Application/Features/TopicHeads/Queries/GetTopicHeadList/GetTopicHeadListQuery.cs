using MediatR;

namespace Internal.Audit.Application.Features.TopicHeads.Queries.GetTopicHeadList;    
public class GetTopicHeadListQuery : IRequest<TopicHeadListPagingDTO>
{
    public int pageSize { get; set; }
    public int pageNumber { get; set; }
    public string? searchTerm { get; set; } = null!;
}

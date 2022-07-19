using AutoMapper;
using Internal.Audit.Application.Contracts.Persistent.TopicHeads;
using MediatR;

namespace Internal.Audit.Application.Features.TopicHeads.Queries.GetTopicHeadList;
public class GetTopicHeadListQueryHandler : IRequestHandler<GetTopicHeadListQuery, TopicHeadListPagingDTO>
{
    private readonly ITopicHeadQueryRepository _repository;
    private readonly IMapper _mapper;

    public GetTopicHeadListQueryHandler(ITopicHeadQueryRepository repository, IMapper mapper)
    {
        _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
    }

    public async Task<TopicHeadListPagingDTO> Handle(GetTopicHeadListQuery request, CancellationToken cancellationToken)
    {
        var (count, result) = await _repository.GetAll(request.pageSize, request.pageNumber, request.searchTerm);

        var list = _mapper.Map<IEnumerable<TopicHeadDTO>>(result).ToList();

        return new TopicHeadListPagingDTO { Items = list, TotalCount = count };
    }
}
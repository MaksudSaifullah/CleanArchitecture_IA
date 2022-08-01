
using AutoMapper;
using Internal.Audit.Application.Contracts.Persistent.TopicHeads;
using MediatR;

namespace Internal.Audit.Application.Features.TopicHeads.Queries.GetTopicHeadByFilter;

public class GetTopicHeadByFilterQueryHandler : IRequestHandler<GetTopicHeadByFilterQuery, IEnumerable<GetTopicHeadByFilterResponseDTO>>
{
    private readonly ITopicHeadQueryRepository _repository;
    private readonly IMapper _mapper;

    public GetTopicHeadByFilterQueryHandler(ITopicHeadQueryRepository repository, IMapper mapper)
    {
        _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
    }

    public async Task<IEnumerable<GetTopicHeadByFilterResponseDTO>> Handle(GetTopicHeadByFilterQuery request, CancellationToken cancellationToken)
    {
        var result = await _repository.GetByFilter(request.Filter.FilterName, request.Filter.FilterValue);
        return _mapper.Map<IEnumerable<GetTopicHeadByFilterResponseDTO>>(result).ToList();
    }
}


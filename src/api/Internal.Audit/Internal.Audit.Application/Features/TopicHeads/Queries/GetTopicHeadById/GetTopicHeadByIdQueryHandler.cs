using AutoMapper;
using Internal.Audit.Application.Contracts.Persistent.TopicHeads;
using MediatR;

namespace Internal.Audit.Application.Features.TopicHeads.Queries.GetTopicHeadById;

public class GetTopicHeadByIdQueryHandler : IRequestHandler<GetTopicHeadByIdQuery, TopicHeadByIdDTO>
{
    private readonly ITopicHeadQueryRepository _repository;
    private readonly IMapper _mapper;

    public GetTopicHeadByIdQueryHandler(ITopicHeadQueryRepository repository, IMapper mapper)
    {
        _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
    }

    public async Task<TopicHeadByIdDTO> Handle(GetTopicHeadByIdQuery request, CancellationToken cancellationToken)
    {
        var result = await _repository.GetById(request.Id);
        return _mapper.Map<TopicHeadByIdDTO>(result);
    }
}


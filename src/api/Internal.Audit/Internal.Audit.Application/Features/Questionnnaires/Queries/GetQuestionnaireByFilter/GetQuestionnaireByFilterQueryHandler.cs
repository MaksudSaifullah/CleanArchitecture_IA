using AutoMapper;
using Internal.Audit.Application.Contracts.Persistent.Questionnnaires;
using MediatR;

namespace Internal.Audit.Application.Features.Questionnnaires.Queries.GetQuestionnaireByFilter;
public class GetQuestionnaireByFilterQueryHandler : IRequestHandler<GetQuestionnaireByFilterQuery, IEnumerable<GetQuestionnaireByFilterResponseDTO>>
{
    private readonly IQuestionnaireQueryRepository _repository;
    private readonly IMapper _mapper;

    public GetQuestionnaireByFilterQueryHandler(IQuestionnaireQueryRepository repository, IMapper mapper)
    {
        _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
    }

    public async Task<IEnumerable<GetQuestionnaireByFilterResponseDTO>> Handle(GetQuestionnaireByFilterQuery request, CancellationToken cancellationToken)
    {
        var result = await _repository.GetByFilter(request.Filter.FilterName, request.Filter.FilterValue);
        return _mapper.Map<IEnumerable<GetQuestionnaireByFilterResponseDTO>>(result).ToList();
    }
}



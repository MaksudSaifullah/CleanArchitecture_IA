using AutoMapper;
using Internal.Audit.Application.Contracts.Persistent.Questionnnaires;
using MediatR;

namespace Internal.Audit.Application.Features.Questionnnaires.Queries.GetQuestionnaireById;
public class GetQuestinonaireByIdQueryHandler : IRequestHandler<GetQuestionnaireByIdQuery, GetQuestionnaireByIdDTO>
{
    private readonly IQuestionnaireQueryRepository _repository;
    private readonly IMapper _mapper;

    public GetQuestinonaireByIdQueryHandler(IQuestionnaireQueryRepository repository, IMapper mapper)
    {
        _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
    }

    public async Task<GetQuestionnaireByIdDTO> Handle(GetQuestionnaireByIdQuery request, CancellationToken cancellationToken)
    {
        var questionnaire = await _repository.GetById(request.Id);
        return _mapper.Map<GetQuestionnaireByIdDTO>(questionnaire);
    }
}

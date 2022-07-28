using AutoMapper;
using Internal.Audit.Application.Contracts.Persistent;
using Internal.Audit.Application.Contracts.Persistent.Questionnnaires;
using Internal.Audit.Domain.Entities.BranchAudit;
using MediatR;


namespace Internal.Audit.Application.Features.Questionnnaires.Commands.AddQuestionnaire;
public class AddQuestionnaireCommandHandler : IRequestHandler<AddQuestionnaireCommand, AddQuestionnaireResponseDTO>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IQuestionnaireCommandRepository _repository;
    private readonly IMapper _mapper;

    public AddQuestionnaireCommandHandler(IQuestionnaireCommandRepository repository, IMapper mapper,
        IUnitOfWork unitOfWork)
    {
        _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
    }
    public async Task<AddQuestionnaireResponseDTO> Handle(AddQuestionnaireCommand request, CancellationToken cancellationToken)
    {
        var questionnaire = _mapper.Map<Questionnaire>(request);
        var newquestionnaire = await _repository.Add(questionnaire);
        var rowsAffected = await _unitOfWork.CommitAsync();

        return new AddQuestionnaireResponseDTO(newquestionnaire.Id, rowsAffected > 0, rowsAffected > 0 ? "Questionnaire Added Successfully!" : "Error while creating Questionnaire !");
    }

}
using AutoMapper;
using Internal.Audit.Application.Contracts.Persistent;
using Internal.Audit.Application.Contracts.Persistent.Questionnnaires;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internal.Audit.Application.Features.Questionnnaires.Commands.DeleteQuestionnaire;
public class DeleteQuestionnaireCommandHandler : IRequestHandler<DeleteQuestionnaireCommand, DeleteQuestionnaireResponseDTO>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IQuestionnaireCommandRepository _repository;
    private readonly IMapper _mapper;

    public DeleteQuestionnaireCommandHandler(IQuestionnaireCommandRepository repository, IMapper mapper, IUnitOfWork unitOfWork)
    {
        _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
    }
    public async Task<DeleteQuestionnaireResponseDTO> Handle(DeleteQuestionnaireCommand request, CancellationToken cancellationToken)
    {
        var questionnaire = await _repository.Get(request.Id);
        questionnaire.IsActive = false;
        questionnaire.IsDeleted = true;
        var mappedquestionnaire = _mapper.Map(request, questionnaire);
        await _repository.Update(mappedquestionnaire);
        var rowsAffected = await _unitOfWork.CommitAsync();
        return new DeleteQuestionnaireResponseDTO(request.Id, rowsAffected > 0, rowsAffected > 0 ? "Questionnaire Deleted Successfully!" : "Error while deleting Questionnaire!");
    }
}

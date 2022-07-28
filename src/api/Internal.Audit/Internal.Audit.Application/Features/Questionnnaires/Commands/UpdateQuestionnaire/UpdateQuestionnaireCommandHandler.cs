using AutoMapper;
using Internal.Audit.Application.Contracts.Persistent;
using Internal.Audit.Application.Contracts.Persistent.Questionnnaires;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internal.Audit.Application.Features.Questionnnaires.Commands.UpdateQuestionnaire;
public class UpdateQuestionnaireCommandHandler : IRequestHandler<UpdateQuestionnaireCommand, UpdateQuestionnaireResponseDTO>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IQuestionnaireCommandRepository _repository;
    private readonly IMapper _mapper;

    public UpdateQuestionnaireCommandHandler(IQuestionnaireCommandRepository repository, IMapper mapper, IUnitOfWork unitOfWork)
    {
        _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
    }

    public async Task<UpdateQuestionnaireResponseDTO> Handle(UpdateQuestionnaireCommand request, CancellationToken cancellationToken)
    {
        var questoinnaire = await _repository.Get(request.Id);
        var mappedquestoinnaire = _mapper.Map(request, questoinnaire);
        var updatedmappedquestoinnaire = await _repository.Update(mappedquestoinnaire);
        var rowsAffected = await _unitOfWork.CommitAsync();
        return new UpdateQuestionnaireResponseDTO(updatedmappedquestoinnaire.Id, rowsAffected > 0, rowsAffected > 0 ? "Questionnaire Updated Successfully!" : "Error while updating Questionnaire!");
    }
}


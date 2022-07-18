using AutoMapper;
using Internal.Audit.Application.Contracts.Persistent;
using Internal.Audit.Application.Contracts.Persistent.RiskCriterias;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internal.Audit.Application.Features.RiskCriterias.Commands.DeleteRiskCriteria;

public class DeleteRiskCriteriaCommandHandler : IRequestHandler<DeleteRiskCriteriaCommand, DeleteRiskCriteriaResponseDTO>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IRiskCriteriaCommandRepository _RiskCriteriaRepository;
    private readonly IMapper _mapper;

    public DeleteRiskCriteriaCommandHandler(IRiskCriteriaCommandRepository RiskCriteriaRepository, IMapper mapper, IUnitOfWork unitOfWork)
    {
        _RiskCriteriaRepository = RiskCriteriaRepository ?? throw new ArgumentNullException(nameof(RiskCriteriaRepository));
        _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
    }

    public async Task<DeleteRiskCriteriaResponseDTO> Handle(DeleteRiskCriteriaCommand request, CancellationToken cancellationToken)
    {
        var RiskCriteria = await _RiskCriteriaRepository.Get(request.Id);
        // RiskProfile.IsActive = false;
        RiskCriteria.IsDeleted = true;
        var mappedRiskCriteria = _mapper.Map(request, RiskCriteria);
        await _RiskCriteriaRepository.Update(mappedRiskCriteria);
        var rowsAffected = await _unitOfWork.CommitAsync();
        return new DeleteRiskCriteriaResponseDTO(request.Id, rowsAffected > 0, rowsAffected > 0 ? "Risk Criteria Deleted Successfully!" : "Error while deleting Risk Criteria!");
    }
}



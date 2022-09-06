using AutoMapper;
using Internal.Audit.Application.Contracts.Persistent;
using Internal.Audit.Application.Contracts.Persistent.RiskCriteriasPCA;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internal.Audit.Application.Features.RiskCriteriasPCA.Commands.DeleteRiskCriteria;

public class DeleteRiskCriteriaCommandHandler : IRequestHandler<DeleteRiskCriteriaPCACommand, DeleteRiskCriteriaPCAResponseDTO>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IRiskCriteriaPCACommandRepository _RiskCriteriaRepository;
    private readonly IMapper _mapper;

    public DeleteRiskCriteriaCommandHandler(IRiskCriteriaPCACommandRepository RiskCriteriaRepository, IMapper mapper, IUnitOfWork unitOfWork)
    {
        _RiskCriteriaRepository = RiskCriteriaRepository ?? throw new ArgumentNullException(nameof(RiskCriteriaRepository));
        _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
    }

    public async Task<DeleteRiskCriteriaPCAResponseDTO> Handle(DeleteRiskCriteriaPCACommand request, CancellationToken cancellationToken)
    {
        var RiskCriteria = await _RiskCriteriaRepository.Get(request.Id);
        // RiskProfile.IsActive = false;
        RiskCriteria.IsDeleted = true;
        var mappedRiskCriteria = _mapper.Map(request, RiskCriteria);
        await _RiskCriteriaRepository.Update(mappedRiskCriteria);
        var rowsAffected = await _unitOfWork.CommitAsync();
        return new DeleteRiskCriteriaPCAResponseDTO(request.Id, rowsAffected > 0, rowsAffected > 0 ? "Risk Criteria Deleted Successfully!" : "Error while deleting Risk Criteria!");
    }
}



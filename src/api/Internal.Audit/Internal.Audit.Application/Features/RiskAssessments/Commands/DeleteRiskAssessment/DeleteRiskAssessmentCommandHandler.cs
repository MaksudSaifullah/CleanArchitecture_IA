using AutoMapper;
using Internal.Audit.Application.Contracts.Persistent;
using Internal.Audit.Application.Contracts.Persistent.AuditPlans;
using Internal.Audit.Application.Contracts.Persistent.RiskAssessments;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internal.Audit.Application.Features.RiskAssessments.Commands.DeleteRiskAssessment;

public class DeleteRiskAssessmentCommandHandler : IRequestHandler<DeleteRiskAssessmentCommand, DeleteRiskAssessmentResponseDTO>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IRiskAssessmentCommandRepository _RiskAssessmentRepository;
    private readonly IAuditPlanCommandRepository _AuditPlanRepository;
    private readonly IMapper _mapper;

    public DeleteRiskAssessmentCommandHandler(IAuditPlanCommandRepository AuditPlanRepository, IRiskAssessmentCommandRepository RiskAssessmentRepository, IMapper mapper, IUnitOfWork unitOfWork)
    {
        _RiskAssessmentRepository = RiskAssessmentRepository ?? throw new ArgumentNullException(nameof(RiskAssessmentRepository));
        _AuditPlanRepository = AuditPlanRepository ?? throw new ArgumentNullException(nameof(RiskAssessmentRepository));
        _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
    }
    public async Task<DeleteRiskAssessmentResponseDTO> Handle(DeleteRiskAssessmentCommand request, CancellationToken cancellationToken)
    {
        var RiskAssessment = await _RiskAssessmentRepository.Get(request.Id);
        var AuditPlan = await _AuditPlanRepository.Get(x=> x.RiskAssessmentId == request.Id);
        if(AuditPlan.Count > 0)
        {
            return new DeleteRiskAssessmentResponseDTO(request.Id, false, "Risk Assessment Has Dependency With Audit Plan! Delete The Child First");
        }
        else
        {
            RiskAssessment.IsDeleted = true;
            var mappedRiskAssessment = _mapper.Map(request, RiskAssessment);
            await _RiskAssessmentRepository.Update(mappedRiskAssessment);
            var rowsAffected = await _unitOfWork.CommitAsync();
            return new DeleteRiskAssessmentResponseDTO(request.Id, rowsAffected > 0, rowsAffected > 0 ? "RiskAssessment Deleted Successfully!" : "Error while deleting RiskAssessment!");
        }

       
    }
}
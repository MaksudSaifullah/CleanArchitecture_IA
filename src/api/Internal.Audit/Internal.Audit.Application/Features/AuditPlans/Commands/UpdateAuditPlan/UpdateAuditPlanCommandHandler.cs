using AutoMapper;
using Internal.Audit.Application.Contracts.Persistent;
using Internal.Audit.Application.Contracts.Persistent.AuditPlans;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internal.Audit.Application.Features.AuditPlans.Commands.UpdateAuditPlan;
public class UpdateAuditPlanCommandHandler : IRequestHandler<UpdateAuditPlanCommand, UpdateAuditPlanResponseDTO>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IAuditPlanCommandRepository _auditPlanRepository;
    private readonly IMapper _mapper;

    public UpdateAuditPlanCommandHandler(IAuditPlanCommandRepository auditPlanRepository, IMapper mapper, IUnitOfWork unitOfWork)
    {
        _auditPlanRepository = auditPlanRepository ?? throw new ArgumentNullException(nameof(auditPlanRepository));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
    }

    public async Task<UpdateAuditPlanResponseDTO> Handle(UpdateAuditPlanCommand request, CancellationToken cancellationToken)
    {
        var auditPlan = await _auditPlanRepository.Get(request.Id);
        var mappedAuditPlan = _mapper.Map(request, auditPlan);
        var updatedAuditPlan = await _auditPlanRepository.Update(mappedAuditPlan);
        var rowsAffected = await _unitOfWork.CommitAsync();
        return new UpdateAuditPlanResponseDTO(updatedAuditPlan.Id, rowsAffected > 0, rowsAffected > 0 ? "Risk Assessment Updated Successfully!" : "Error while updating Risk Assessment!");
    }
}

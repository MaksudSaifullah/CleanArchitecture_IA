using AutoMapper;
using Internal.Audit.Application.Contracts.Persistent;
using Internal.Audit.Application.Contracts.Persistent.AuditPlans;
using Internal.Audit.Domain.Entities.BranchAudit;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internal.Audit.Application.Features.AuditPlans.Commands.AddAuditPlan;

public class AddAuditPlanCommandHandler : IRequestHandler<AddAuditPlanCommand, AddAuditPlanResponseDTO>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IAuditPlanCommandRepository _auditPlanRepository;
    private readonly IMapper _mapper;

    public AddAuditPlanCommandHandler(IAuditPlanCommandRepository auditPlanRepository, IMapper mapper,
        IUnitOfWork unitOfWork)
    {
        _auditPlanRepository = auditPlanRepository ?? throw new ArgumentNullException(nameof(auditPlanRepository));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
    }
    public async Task<AddAuditPlanResponseDTO> Handle(AddAuditPlanCommand request, CancellationToken cancellationToken)
    {
        var auditPlan = _mapper.Map<AuditPlan>(request);
        var newauditPlan = await _auditPlanRepository.Add(auditPlan);
        var rowsAffected = await _unitOfWork.CommitAsync();

        return new AddAuditPlanResponseDTO(newauditPlan.Id, rowsAffected > 0, rowsAffected > 0 ? "Audit Plan Added Successfully!" : "Error while creating Risk Assessment !");
    }

}
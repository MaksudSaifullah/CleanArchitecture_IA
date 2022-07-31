using AutoMapper;
using Internal.Audit.Application.Contracts.Persistent.AuditPlans;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internal.Audit.Application.Features.AuditPlans.Queries.GetAuditPlanById;
public class GetAuditPlanQueryHandler : IRequestHandler<GetAuditPlanQuery, AuditPlanByIdDTO>
{
    private readonly IAuditPlanQueryRepository _auditPlanRepository;
    private readonly IMapper _mapper;

    public GetAuditPlanQueryHandler(IAuditPlanQueryRepository auditPlanRepository, IMapper mapper)
    {
        _auditPlanRepository = auditPlanRepository ?? throw new ArgumentNullException(nameof(auditPlanRepository));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
    }

    public async Task<AuditPlanByIdDTO> Handle(GetAuditPlanQuery request, CancellationToken cancellationToken)
    {
        var auditPlan = await _auditPlanRepository.GetById(request.Id);
        return _mapper.Map<AuditPlanByIdDTO>(auditPlan);
    }
}
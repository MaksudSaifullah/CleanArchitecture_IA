using AutoMapper;
using Internal.Audit.Application.Contracts.Persistent.AuditSchedules;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internal.Audit.Application.Features.AuditSchedules.Queries.GetAuditScheduleByPlanId;

public class GetAuditScheduleByPlanIdQueryHandler : IRequestHandler<GetAuditScheduleByPlanIdQuery, IEnumerable<GetAuditSchedulePlanIdResponseDTO>>
{
    private readonly IAuditScheduleBaseQueryRepository _auditScheduleRepository;
    private readonly IMapper _mapper;

    public GetAuditScheduleByPlanIdQueryHandler(IAuditScheduleBaseQueryRepository auditScheduleRepository, IMapper mapper)
    {
        _auditScheduleRepository = auditScheduleRepository ?? throw new ArgumentNullException(nameof(auditScheduleRepository));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
    }

    public async Task<IEnumerable<GetAuditSchedulePlanIdResponseDTO>> Handle(GetAuditScheduleByPlanIdQuery request, CancellationToken cancellationToken)
    {
        var list = await _auditScheduleRepository.GetAuditScheduleById(request.AuditSchduleId);
        return _mapper.Map<IEnumerable<GetAuditSchedulePlanIdResponseDTO>>(list);
        

    }
}

using AutoMapper;
using Internal.Audit.Application.Contracts.Persistent.AuditSchedules;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internal.Audit.Application.Features.AuditSchedules.Queries.GetAuditScheduleById;

public class GetAuditScheduleQueryHandler : IRequestHandler<GetAuditScheduleQuery, AuditScheduleByIdDTO>
{
    private readonly IAuditScheduleQueryRepository _auditScheduleRepository;
    private readonly IMapper _mapper;

    public GetAuditScheduleQueryHandler(IAuditScheduleQueryRepository auditScheduleRepository, IMapper mapper)
    {
        _auditScheduleRepository = auditScheduleRepository ?? throw new ArgumentNullException(nameof(auditScheduleRepository));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
    }

    public async Task<AuditScheduleByIdDTO> Handle(GetAuditScheduleQuery request, CancellationToken cancellationToken)
    {
        var auditPlan = await _auditScheduleRepository.GetById(request.Id);
        return _mapper.Map<AuditScheduleByIdDTO>(auditPlan);
    }
}
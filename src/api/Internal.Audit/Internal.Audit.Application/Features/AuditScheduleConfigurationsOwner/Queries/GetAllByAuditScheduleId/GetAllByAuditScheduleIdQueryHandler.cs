using AutoMapper;
using Internal.Audit.Application.Contracts.Persistent.AuditScheduleConfigurationsOwner;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internal.Audit.Application.Features.AuditScheduleConfigurationsOwner.Queries.GetAllByAuditScheduleId;

public class GetAllByAuditScheduleIdQueryHandler : IRequestHandler<GetAllByAuditScheduleIdQuery, GetAllByAuditScheduledIdResponseDTO>
{
    private readonly IAuditScheduleConfigurationOwnerQueryRepository _auditScheduleConfigurationRepository;
    private readonly IMapper _mapper;
    public GetAllByAuditScheduleIdQueryHandler(IAuditScheduleConfigurationOwnerQueryRepository auditScheduleConfigurationRepository, IMapper mapper)
    {
        _auditScheduleConfigurationRepository = auditScheduleConfigurationRepository ?? throw new ArgumentNullException(nameof(auditScheduleConfigurationRepository));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
    }
    public async Task<GetAllByAuditScheduledIdResponseDTO> Handle(GetAllByAuditScheduleIdQuery request, CancellationToken cancellationToken)
    {
        var result = await _auditScheduleConfigurationRepository.GetAllAsync(request.AuditScheduleId,request.TypeId);
        var auditScheduleList = _mapper.Map<GetAllByAuditScheduledIdResponseDTO>(result);
        return auditScheduleList;
    }
}

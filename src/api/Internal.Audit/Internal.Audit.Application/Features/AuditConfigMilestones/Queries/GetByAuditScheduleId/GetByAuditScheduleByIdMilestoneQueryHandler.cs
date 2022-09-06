using AutoMapper;
using Internal.Audit.Application.Contracts.Persistent.AuditConfigMilestones;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internal.Audit.Application.Features.AuditConfigMilestones.Queries.GetByAuditScheduleId;

public class GetByAuditScheduleByIdMilestoneQueryHandler : IRequestHandler<GetByAuditScheduleByIdMilestoneQuery, IEnumerable<GetByAuditScheduleByIdMilestoneQueryResponseDTO>>
{
    private readonly IAuditConfigMilestoneQueryReposiotry _auditScheduleConfigurationRepository;
    private readonly IMapper _mapper;
    public GetByAuditScheduleByIdMilestoneQueryHandler(IAuditConfigMilestoneQueryReposiotry auditScheduleConfigurationRepository, IMapper mapper)
    {
        _auditScheduleConfigurationRepository = auditScheduleConfigurationRepository ?? throw new ArgumentNullException(nameof(auditScheduleConfigurationRepository));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
    }
    public async Task<IEnumerable<GetByAuditScheduleByIdMilestoneQueryResponseDTO>> Handle(GetByAuditScheduleByIdMilestoneQuery request, CancellationToken cancellationToken)
    {
        var result =await _auditScheduleConfigurationRepository.GetByAuditScheduleId(request.Id);
        return _mapper.Map<IEnumerable<GetByAuditScheduleByIdMilestoneQueryResponseDTO>>(result);
       
    }
}

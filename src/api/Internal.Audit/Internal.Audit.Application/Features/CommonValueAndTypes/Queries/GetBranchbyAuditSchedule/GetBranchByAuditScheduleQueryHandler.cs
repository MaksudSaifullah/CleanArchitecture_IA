using AutoMapper;
using Internal.Audit.Application.Contracts.Persistent.AuditScheduleBranches;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internal.Audit.Application.Features.CommonValueAndTypes.Queries.GetBranchbyAuditSchedule;


public class GetBranchByAuditScheduleQueryHandler : IRequestHandler<GetBranchByAuditScheduleQuery, IEnumerable<BranchByScheduleIdDTO>>
{
    private readonly IAuditScheduleBranchQueryRepository _auditScheduleBranchRepository;
    private readonly IMapper _mapper;

    public GetBranchByAuditScheduleQueryHandler(IAuditScheduleBranchQueryRepository auditScheduleBranchRepository, IMapper mapper)
    {
        _auditScheduleBranchRepository = auditScheduleBranchRepository ?? throw new ArgumentNullException(nameof(auditScheduleBranchRepository));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
    }


    public async Task<IEnumerable<BranchByScheduleIdDTO>> Handle(GetBranchByAuditScheduleQuery request, CancellationToken cancellationToken)
    {
        var auditScheduleBranch = await _auditScheduleBranchRepository.GetByScheduleId(request.Id);
        return _mapper.Map<IList<BranchByScheduleIdDTO>>(auditScheduleBranch);
    }
}
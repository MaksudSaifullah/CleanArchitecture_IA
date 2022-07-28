using AutoMapper;
using Internal.Audit.Application.Contracts.Persistent.AuditPlans;
using Internal.Audit.Domain.CompositeEntities.BranchAudit;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internal.Audit.Application.Features.AuditPlans.Queries.GetAuditPlanList
{
    public class GetAuditPlanListQueryHandler : IRequestHandler<GetAuditPlanListQuery, AuditPlanListPagingDTO>
    {
        private readonly IAuditPlanQueryRepository _auditPlanRepository;
        private readonly IMapper _mapper;

        public GetAuditPlanListQueryHandler(IAuditPlanQueryRepository auditPlanRepository, IMapper mapper)
        {
            _auditPlanRepository = auditPlanRepository ?? throw new ArgumentNullException(nameof(auditPlanRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<AuditPlanListPagingDTO> Handle(GetAuditPlanListQuery request, CancellationToken cancellationToken)
        {
            (long, IEnumerable<CompositeAuditPlan>) result = await _auditPlanRepository.GetAll(request.pageSize, request.pageNumber, request.searchTerm);

            var auditPlanList = _mapper.Map<List<AuditPlanDTO>>(result.Item2);

            return new AuditPlanListPagingDTO { Items = auditPlanList, TotalCount = result.Item1 };
        }
    }
}

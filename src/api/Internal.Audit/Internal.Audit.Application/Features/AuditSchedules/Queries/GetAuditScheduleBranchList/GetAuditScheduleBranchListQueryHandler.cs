using AutoMapper;
using Internal.Audit.Application.Contracts.Persistent.AuditSchedules;
using Internal.Audit.Domain.CompositeEntities.BranchAudit;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internal.Audit.Application.Features.AuditSchedules.Queries.GetAuditScheduleBranchList
{
    public class GetAuditScheduleBranchListQueryHandler : IRequestHandler<GetAuditScheduleBranchListQuery, GetAuditScheduleBranchListPagingDTO>
    {
        private readonly IAuditScheduleBranchListQueryRepository _auditScheduleBranchRepository;
        private readonly IMapper _mapper;
        public GetAuditScheduleBranchListQueryHandler(IAuditScheduleBranchListQueryRepository auditScheduleBranchRepository, IMapper mapper)
        {
            _auditScheduleBranchRepository = auditScheduleBranchRepository ?? throw new ArgumentNullException(nameof(auditScheduleBranchRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }
        public async Task<GetAuditScheduleBranchListPagingDTO> Handle(GetAuditScheduleBranchListQuery request, CancellationToken cancellationToken)
        {
            var (count, result) = await _auditScheduleBranchRepository.GetAll(request.searchTerm.scheduleId, request.pageSize,  request.pageNumber);
            var auditScheduleList = _mapper.Map<IEnumerable<CompositAuditScheduleBranch>, IEnumerable<GetAuditScheduleBranchListResponseDTO>>(result).ToList();

            return new GetAuditScheduleBranchListPagingDTO { Items = auditScheduleList, TotalCount = count };
        }
    }
}

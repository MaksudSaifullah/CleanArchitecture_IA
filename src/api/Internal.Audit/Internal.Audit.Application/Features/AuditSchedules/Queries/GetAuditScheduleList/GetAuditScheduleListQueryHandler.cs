using AutoMapper;
using Internal.Audit.Application.Contracts.Persistent.AuditSchedules;
using Internal.Audit.Application.Features.EmailConfig.Queries.GetEmailConfigList;
using Internal.Audit.Domain.CompositeEntities.BranchAudit;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internal.Audit.Application.Features.AuditSchedules.Queries.GetAuditScheduleList
{
    public class GetAuditScheduleListQueryHandler : IRequestHandler<GetAuditScheduleListQuery, GetAuditScheduleListPagingDTO>
    {
        private readonly IAuditScheduleQueryRepository _auditScheduleueryRepository;
        private readonly IMapper _mapper;
        public GetAuditScheduleListQueryHandler(IAuditScheduleQueryRepository auditScheduleueryRepository, IMapper mapper)
        {
            _auditScheduleueryRepository = auditScheduleueryRepository ?? throw new ArgumentNullException(nameof(auditScheduleueryRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }
        public async Task<GetAuditScheduleListPagingDTO> Handle(GetAuditScheduleListQuery request, CancellationToken cancellationToken)
        {
            var (count, result) = await _auditScheduleueryRepository.GetAll(request.searchTerm.scheduleId, request.searchTerm.auditCreationId, request.pageSize, request.pageNumber);
            var auditScheduleList = _mapper.Map<IEnumerable<CompositAuditSchedule>, IEnumerable<GetAuditScheduleListResponseDTO>>(result).ToList();

            return new GetAuditScheduleListPagingDTO { Items = auditScheduleList, TotalCount = count };
        }
    }
}

using AutoMapper;
using Internal.Audit.Application.Contracts.Persistent.AuditScheduleConfigurationsOwner;
using Internal.Audit.Domain.CompositeEntities.BranchAudit;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internal.Audit.Application.Features.AuditScheduleConfigurationsOwner.Queries.GetOwnerList
{
    public class GetOwnerListHandler : IRequestHandler<GetOwnerListQuery, GetOwnerListPagingDTO>
    {
        private readonly IAuditScheduleOwnerListQueryRepository _auditScheduleOwnerListQueryRepository;
        private readonly IMapper _mapper;
        public GetOwnerListHandler(IAuditScheduleOwnerListQueryRepository auditScheduleOwnerListQueryRepository, IMapper mapper)
        {
            _auditScheduleOwnerListQueryRepository = auditScheduleOwnerListQueryRepository ?? throw new ArgumentNullException(nameof(auditScheduleOwnerListQueryRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }
        public async Task<GetOwnerListPagingDTO> Handle(GetOwnerListQuery request, CancellationToken cancellationToken)
        {
            var (count, result) = await _auditScheduleOwnerListQueryRepository.GetAll(request.searchTerm.auditScheduleId,request.searchTerm.ownerTypeId, request.pageSize, request.pageNumber);
            var auditScheduleOwnerList = _mapper.Map<IEnumerable<CompositAuditScheduleOwner>, IEnumerable<GetOwnerListResponseDTO>>(result).ToList();

            return new GetOwnerListPagingDTO { Items = auditScheduleOwnerList, TotalCount = count };
        }
    }
}

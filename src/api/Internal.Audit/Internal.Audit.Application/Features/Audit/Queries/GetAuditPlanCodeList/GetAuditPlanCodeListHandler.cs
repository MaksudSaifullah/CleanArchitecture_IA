using AutoMapper;
using Internal.Audit.Application.Contracts.Persistent.Audit;
using Internal.Audit.Domain.CompositeEntities.BranchAudit;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internal.Audit.Application.Features.Audit.Queries.GetAuditPlanCodeList
{
    public class GetAuditPlanCodeListHandler: IRequestHandler<GetAuditPlanCodeListQuery, AuditPlanCodePagingDTO>
    {
        private readonly IAuditPlanCodeQueryRepository _auditPlanCodeQueryRepository;
        private readonly IMapper _mapper;
        public GetAuditPlanCodeListHandler(IAuditPlanCodeQueryRepository auditPlanCodeQueryRepository, IMapper mapper)
        {
            _auditPlanCodeQueryRepository = auditPlanCodeQueryRepository ?? throw new ArgumentNullException(nameof(auditPlanCodeQueryRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<AuditPlanCodePagingDTO> Handle(GetAuditPlanCodeListQuery request, CancellationToken cancellationToken)
        {
            var (count, result) = await _auditPlanCodeQueryRepository.GetAll(request.searchTerm.countryId,request.searchTerm.auditTypeId, request.pageSize, request.pageNumber);
            var auditPlanCodeList = _mapper.Map<IEnumerable<AuditPlanCode>, IEnumerable<GetAuditPlanCodeListResponseDTO>>(result).ToList();

            return new AuditPlanCodePagingDTO { Items = auditPlanCodeList, TotalCount = count };
        }
    }
}

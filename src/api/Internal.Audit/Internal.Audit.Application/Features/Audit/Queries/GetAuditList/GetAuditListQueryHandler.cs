using AutoMapper;
using Internal.Audit.Application.Contracts.Persistent.Audit;
using Internal.Audit.Domain.CompositeEntities.BranchAudit;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internal.Audit.Application.Features.Audit.Queries.GetAuditList
{
    public class GetAuditListQueryHandler : IRequestHandler<GetAuditListQuery, GetAuditListPagingDTO>
    {
        private readonly IAuditQueryRepository _auditQueryRepository;
        private readonly IMapper _mapper;
        public GetAuditListQueryHandler(IAuditQueryRepository auditQueryRepository, IMapper mapper)
        {
            _auditQueryRepository = auditQueryRepository ?? throw new ArgumentNullException(nameof(auditQueryRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }
        public async Task<GetAuditListPagingDTO> Handle(GetAuditListQuery request, CancellationToken cancellationToken)
        {
            var (count, result) = await _auditQueryRepository.GetAll(request.searchTerm.auditId, request.pageSize, request.pageNumber);
            var auditList = _mapper.Map<IEnumerable<CompositAudit>, IEnumerable<GetAuditListResponseDTO>>(result).ToList();

            return new GetAuditListPagingDTO { Items = auditList, TotalCount = count };
        }
    }
}

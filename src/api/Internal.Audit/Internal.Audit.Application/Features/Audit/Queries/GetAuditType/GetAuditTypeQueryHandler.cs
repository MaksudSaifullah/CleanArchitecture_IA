using AutoMapper;
using Internal.Audit.Application.Contracts.Persistent.Audit;
using Internal.Audit.Domain.Entities.Config;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internal.Audit.Application.Features.Audit.Queries.GetAuditType
{
    public class GetAuditTypeQueryHandler: IRequestHandler<GetAuditTypeQuery, AuditTypePagingDTO>
    {
        private readonly IAuditTypeQueryRepository _auditTypeQueryRepository;
        private readonly IMapper _mapper;
        public GetAuditTypeQueryHandler(IAuditTypeQueryRepository auditTypeQueryRepository, IMapper mapper)
        {
            _auditTypeQueryRepository = auditTypeQueryRepository ?? throw new ArgumentNullException(nameof(auditTypeQueryRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<AuditTypePagingDTO> Handle(GetAuditTypeQuery request, CancellationToken cancellationToken)
        {
            var (count, result) = await _auditTypeQueryRepository.GetAll( request.pageSize, request.pageNumber);
            var auditTypeList = _mapper.Map<IEnumerable<AuditType>, IEnumerable<GetAuditTypeResponseDTO>>(result).ToList();

            return new AuditTypePagingDTO { Items = auditTypeList, TotalCount = count };
        }
    }
}

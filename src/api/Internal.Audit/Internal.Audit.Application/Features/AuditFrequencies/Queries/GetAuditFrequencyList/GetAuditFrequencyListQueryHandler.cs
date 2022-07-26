using AutoMapper;
using Internal.Audit.Application.Contracts.Persistent.AuditFrequencies;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internal.Audit.Application.Features.AuditFrequencies.Queries.GetAuditFrequencyList
{
    public class GetAuditFrequencyListQueryHandler : IRequestHandler<GetAuditFrequencyListQuery, AuditFrequencyListPagingDTO>
    {
        private readonly IAuditFrequencyQueryRepository _auditfrequencyRepository;
        private readonly IMapper _mapper;

        public GetAuditFrequencyListQueryHandler(IAuditFrequencyQueryRepository auditfrequencyRepository, IMapper mapper)
        {
            _auditfrequencyRepository = auditfrequencyRepository ?? throw new ArgumentNullException(nameof(auditfrequencyRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }



        public async Task<AuditFrequencyListPagingDTO> Handle(GetAuditFrequencyListQuery request, CancellationToken cancellationToken)
        {
            var (count, result) = await _auditfrequencyRepository.GetAll(request.pageSize, request.pageNumber);

            var auditFrequencyList = _mapper.Map<IEnumerable<AuditFrequencyDTO>>(result).ToList();

            return new AuditFrequencyListPagingDTO { Items = auditFrequencyList, TotalCount = count };
        }
    }
}

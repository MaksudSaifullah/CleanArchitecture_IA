using AutoMapper;
using Internal.Audit.Application.Contracts.Persistent.AuditFrequencies;
using Internal.Audit.Domain.CompositeEntities;
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
            (long, IEnumerable<CompositeAuditFrequency>) result = await _auditfrequencyRepository.GetAll(request.pageSize, request.pageNumber, request.searchTerm);

            var auditFrequencyList = _mapper.Map<List<AuditFrequencyDTO>>(result.Item2);

            return new AuditFrequencyListPagingDTO { Items = auditFrequencyList, TotalCount = result.Item1 };
          
        }
    }
}

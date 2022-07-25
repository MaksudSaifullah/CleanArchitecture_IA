using AutoMapper;
using Internal.Audit.Application.Contracts.Persistent.Audit;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internal.Audit.Application.Features.Audit.Queries.GetAuditById
{
    public class GetAuditQueryHandler : IRequestHandler<GetAuditQuery, GetAuditByIdResponseDTO>
    {
        private readonly IAuditQueryRepository _auditQueryRepository;
        private readonly IMapper _mapper;
        public GetAuditQueryHandler(IAuditQueryRepository auditQueryRepository, IMapper mapper)
        {
            _auditQueryRepository = auditQueryRepository ?? throw new ArgumentNullException(nameof(auditQueryRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }
        public async Task<GetAuditByIdResponseDTO> Handle(GetAuditQuery request, CancellationToken cancellationToken)
        {
            var country = await _auditQueryRepository.GetById(request.Id);
            return _mapper.Map<GetAuditByIdResponseDTO>(country);
        }
    }
}

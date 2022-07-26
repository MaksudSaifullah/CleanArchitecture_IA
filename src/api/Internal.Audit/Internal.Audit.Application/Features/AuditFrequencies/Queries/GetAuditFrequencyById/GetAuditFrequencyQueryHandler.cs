using AutoMapper;
using Internal.Audit.Application.Contracts.Persistent.AuditFrequencies;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internal.Audit.Application.Features.AuditFrequencies.Queries.GetAuditFrequencyById;

public class GetAuditFrequencyQueryHandler : IRequestHandler<GetAuditFrequencyQuery, AuditFrequencyByIdDTO>
{
    private readonly IAuditFrequencyQueryRepository _auditfrequencyRepository;
    private readonly IMapper _mapper;
    
    public GetAuditFrequencyQueryHandler(IAuditFrequencyQueryRepository auditfrequencyRepository, IMapper mapper)
    {
        _auditfrequencyRepository = auditfrequencyRepository ?? throw new ArgumentNullException(nameof(auditfrequencyRepository));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
    }

    public async Task<AuditFrequencyByIdDTO> Handle(GetAuditFrequencyQuery request, CancellationToken cancellationToken)
    {
        var riskCriteria = await _auditfrequencyRepository.GetById(request.Id);
        return _mapper.Map<AuditFrequencyByIdDTO>(riskCriteria);
    }
}

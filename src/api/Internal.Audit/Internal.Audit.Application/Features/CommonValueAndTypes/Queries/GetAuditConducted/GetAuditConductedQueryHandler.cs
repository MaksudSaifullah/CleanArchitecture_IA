using AutoMapper;
using Internal.Audit.Application.Contracts.Persistent.CommonValueAndTypes;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internal.Audit.Application.Features.CommonValueAndTypes.Queries.GetAuditConducted;
public class GetAuditConductedQueryHandler : IRequestHandler<GetAuditConductedQuery, AuditConductedDTO>
{
    private readonly ICommonValueAndTypeQueryRepository _commonValueAndTypeRepository;
    private readonly IMapper _mapper;

    public GetAuditConductedQueryHandler(ICommonValueAndTypeQueryRepository commonValueAndTypeRepository, IMapper mapper)
    {
        _commonValueAndTypeRepository = commonValueAndTypeRepository ?? throw new ArgumentNullException(nameof(commonValueAndTypeRepository));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
    }

    public async Task<AuditConductedDTO> Handle(GetAuditConductedQuery request, CancellationToken cancellationToken)
    {
        var commonValueAndType = await _commonValueAndTypeRepository.GetEMailType();
        return _mapper.Map<AuditConductedDTO>(commonValueAndType);
    }
}

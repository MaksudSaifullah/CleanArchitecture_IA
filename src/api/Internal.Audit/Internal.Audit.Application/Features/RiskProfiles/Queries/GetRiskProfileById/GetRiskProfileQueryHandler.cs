using AutoMapper;
using Internal.Audit.Application.Contracts.Persistent.RiskProfiles;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internal.Audit.Application.Features.RiskProfiles.Queries.GetRiskProfileById;
public class GetRiskProfileQueryHandler : IRequestHandler<GetRiskProfileQuery, RiskProfileByIdDTO>
{
    private readonly IRiskProfileQueryRepository _riskProfileRepository;
    private readonly IMapper _mapper;

    public GetRiskProfileQueryHandler(IRiskProfileQueryRepository riskProfileRepository, IMapper mapper)
    {
        _riskProfileRepository = riskProfileRepository ?? throw new ArgumentNullException(nameof(riskProfileRepository));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
    }

    public async Task<RiskProfileByIdDTO> Handle(GetRiskProfileQuery request, CancellationToken cancellationToken)
    {
        var riskProfile = await _riskProfileRepository.GetById(request.Id);
        return _mapper.Map<RiskProfileByIdDTO>(riskProfile);
    }
}

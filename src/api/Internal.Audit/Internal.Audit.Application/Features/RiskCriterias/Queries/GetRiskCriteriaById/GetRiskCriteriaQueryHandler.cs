using AutoMapper;
using Internal.Audit.Application.Contracts.Persistent.RiskCriterias;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internal.Audit.Application.Features.RiskCriterias.Queries.GetRiskCriteriaById;
public class GetRiskCriteriaQueryHandler : IRequestHandler<GetRiskCriteriaQuery, RiskCriteriaByIdDTO>
{
    private readonly IRiskCriteriaQueryRepository _riskCriteriaRepository;
    private readonly IMapper _mapper;

    public GetRiskCriteriaQueryHandler(IRiskCriteriaQueryRepository riskProfileRepository, IMapper mapper)
    {
        _riskCriteriaRepository = riskProfileRepository ?? throw new ArgumentNullException(nameof(riskProfileRepository));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
    }

    public async Task<RiskCriteriaByIdDTO> Handle(GetRiskCriteriaQuery request, CancellationToken cancellationToken)
    {
        var riskCriteria = await _riskCriteriaRepository.GetById(request.Id);
        return _mapper.Map<RiskCriteriaByIdDTO>(riskCriteria);
    }
}

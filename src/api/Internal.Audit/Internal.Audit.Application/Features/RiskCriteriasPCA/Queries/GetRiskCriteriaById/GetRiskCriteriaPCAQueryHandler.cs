using AutoMapper;
using Internal.Audit.Application.Contracts.Persistent.RiskCriteriasPCA;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internal.Audit.Application.Features.RiskCriteriasPCA.Queries.GetRiskCriteriaById;
public class GetRiskCriteriaPCAQueryHandler : IRequestHandler<GetRiskCriteriaPCAQuery, RiskCriteriaPCAByIdDTO>
{
    private readonly IRiskCriteriaPCAQueryRepository _riskCriteriaRepository;
    private readonly IMapper _mapper;

    public GetRiskCriteriaPCAQueryHandler(IRiskCriteriaPCAQueryRepository riskProfileRepository, IMapper mapper)
    {
        _riskCriteriaRepository = riskProfileRepository ?? throw new ArgumentNullException(nameof(riskProfileRepository));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
    }

    public async Task<RiskCriteriaPCAByIdDTO> Handle(GetRiskCriteriaPCAQuery request, CancellationToken cancellationToken)
    {
        var riskCriteria = await _riskCriteriaRepository.GetById(request.Id);
        return _mapper.Map<RiskCriteriaPCAByIdDTO>(riskCriteria);
    }
}

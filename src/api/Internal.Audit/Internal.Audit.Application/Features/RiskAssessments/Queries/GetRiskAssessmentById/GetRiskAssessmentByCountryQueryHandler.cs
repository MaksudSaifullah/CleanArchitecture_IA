using AutoMapper;
using Internal.Audit.Application.Contracts.Persistent.RiskAssessments;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Internal.Audit.Application.Features.RiskAssessments.Queries.GetRiskAssessmentById;
public class GetRiskAssessmentByCountryQueryHandler : IRequestHandler<GetRiskAssessmentByCountryQuery, IEnumerable<RiskAssessmentByIdDTO>>
{
    private readonly IRiskAssessmentQueryRepository _riskAssessmentRepository;
    private readonly IMapper _mapper;

    public GetRiskAssessmentByCountryQueryHandler(IRiskAssessmentQueryRepository riskAssessmentRepository, IMapper mapper)
    {
        _riskAssessmentRepository = riskAssessmentRepository ?? throw new ArgumentNullException(nameof(riskAssessmentRepository));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
    }


    public async Task<IEnumerable<RiskAssessmentByIdDTO>> Handle(GetRiskAssessmentByCountryQuery request, CancellationToken cancellationToken)
    {
        var riskAssessment = await _riskAssessmentRepository.GetByCountryId(request.Id);
        return _mapper.Map<IList<RiskAssessmentByIdDTO>>(riskAssessment);
    }
}
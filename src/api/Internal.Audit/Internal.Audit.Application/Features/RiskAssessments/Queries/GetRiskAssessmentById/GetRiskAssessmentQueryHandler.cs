using AutoMapper;
using Internal.Audit.Application.Contracts.Persistent.RiskAssessments;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internal.Audit.Application.Features.RiskAssessments.Queries.GetRiskAssessmentById;
public class GetRiskAssessmentQueryHandler : IRequestHandler<GetRiskAssessmentQuery, RiskAssessmentByIdDTO>
{
    private readonly IRiskAssessmentQueryRepository _riskAssessmentRepository;
    private readonly IMapper _mapper;

    public GetRiskAssessmentQueryHandler(IRiskAssessmentQueryRepository riskAssessmentRepository, IMapper mapper)
    {
        _riskAssessmentRepository = riskAssessmentRepository ?? throw new ArgumentNullException(nameof(riskAssessmentRepository));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
    }

    public async Task<RiskAssessmentByIdDTO> Handle(GetRiskAssessmentQuery request, CancellationToken cancellationToken)
    {
        var riskAssessment = await _riskAssessmentRepository.GetById(request.Id);
        return _mapper.Map<RiskAssessmentByIdDTO>(riskAssessment);
    }
}
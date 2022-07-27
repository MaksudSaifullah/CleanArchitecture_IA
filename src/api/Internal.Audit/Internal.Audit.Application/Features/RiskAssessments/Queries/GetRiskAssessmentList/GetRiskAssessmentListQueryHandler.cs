using AutoMapper;
using Internal.Audit.Application.Contracts.Persistent.RiskAssessments;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internal.Audit.Application.Features.RiskAssessments.Queries.GetRiskAssessmentList
{
    public class GetRiskAssessmentListQueryHandler : IRequestHandler<GetRiskAssessmentListQuery, RiskAssessmentListPagingDTO>
    {
        private readonly IRiskAssessmentQueryRepository _riskAssessmentRepository;
        private readonly IMapper _mapper;

        public GetRiskAssessmentListQueryHandler(IRiskAssessmentQueryRepository riskAssessmentRepository, IMapper mapper)
        {
            _riskAssessmentRepository = riskAssessmentRepository ?? throw new ArgumentNullException(nameof(riskAssessmentRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<RiskAssessmentListPagingDTO> Handle(GetRiskAssessmentListQuery request, CancellationToken cancellationToken)
        {
            var (count, result) = await _riskAssessmentRepository.GetAll(request.pageSize, request.pageNumber);

            var riskAssessmentList = _mapper.Map<IEnumerable<RiskAssessmentDTO>>(result).ToList();

            return new RiskAssessmentListPagingDTO { Items = riskAssessmentList, TotalCount = count };
        }
    }
}

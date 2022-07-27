using AutoMapper;
using Internal.Audit.Application.Contracts.Persistent.RiskAssessments;
using Internal.Audit.Domain.CompositeEntities.BranchAudit;
using Internal.Audit.Domain.Entities.BranchAudit;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internal.Audit.Application.Features.RiskAssessments.Queries.GetRiskAssessmentList
{
    public class SearchArea
    {
        public string searchTerm { get; set; }
        public string year { get; set; }
    }
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
            string searchTermRaw = (object)request.searchTerm == null ? null : Convert.ToString(request.searchTerm);
            SearchArea searchArea = Newtonsoft.Json.JsonConvert.DeserializeObject<SearchArea>(searchTermRaw);
            string yearConverted = string.Empty;
            string searchTermConverted = string.Empty;
            searchTermConverted = searchArea.searchTerm;
            yearConverted = searchArea.year;

            (long, IEnumerable<CompositeRiskAssessment>) riskAssessment = await _riskAssessmentRepository.GetAll(request.pageSize, request.pageNumber, searchTermConverted , yearConverted);
            var riskAssessmentList = _mapper.Map<List<RiskAssessmentDTO>>(riskAssessment.Item2);
            return new RiskAssessmentListPagingDTO { Items = riskAssessmentList, TotalCount = riskAssessment.Item1 };
        }
    }
}

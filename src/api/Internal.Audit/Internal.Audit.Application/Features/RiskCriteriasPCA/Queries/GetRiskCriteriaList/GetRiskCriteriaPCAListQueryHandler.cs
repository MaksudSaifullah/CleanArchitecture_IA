using AutoMapper;
using Internal.Audit.Application.Contracts.Persistent.RiskCriteriasPCA;
using Internal.Audit.Domain.CompositeEntities.ProcessAndControlAudit;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internal.Audit.Application.Features.RiskCriteriasPCA.Queries.GetRiskCriteriaList
{
    public class GetRiskCriteriaPCAListQueryHandler : IRequestHandler<GetRiskCriteriaPCAListQuery, RiskCriteriaPCAListPagingDTO>
    {
        private readonly IRiskCriteriaPCAQueryRepository _riskCriteriaRepository;
        private readonly IMapper _mapper;

        public GetRiskCriteriaPCAListQueryHandler(IRiskCriteriaPCAQueryRepository riskCriteriaRepository, IMapper mapper)
        {
            _riskCriteriaRepository = riskCriteriaRepository ?? throw new ArgumentNullException(nameof(riskCriteriaRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }



        public async Task<RiskCriteriaPCAListPagingDTO> Handle(GetRiskCriteriaPCAListQuery request, CancellationToken cancellationToken)
        {

            (long, IEnumerable<CompositeRiskCriteriaPCA>) result = await _riskCriteriaRepository.GetAll(request.pageSize, request.pageNumber, request.searchTerm);

            var riskCriteriaList = _mapper.Map<List<RiskCriteriaPCADTO>>(result.Item2);

            return new RiskCriteriaPCAListPagingDTO { Items = riskCriteriaList, TotalCount = result.Item1 };
        }
    }
}

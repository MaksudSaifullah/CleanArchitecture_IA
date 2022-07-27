using AutoMapper;
using Internal.Audit.Application.Contracts.Persistent.RiskCriterias;
using Internal.Audit.Domain.CompositeEntities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internal.Audit.Application.Features.RiskCriterias.Queries.GetRiskCriteriaList
{
    public class GetRiskCriteriaListQueryHandler : IRequestHandler<GetRiskCriteriaListQuery, RiskCriteriaListPagingDTO>
    {
        private readonly IRiskCriteriaQueryRepository _riskCriteriaRepository;
        private readonly IMapper _mapper;

        public GetRiskCriteriaListQueryHandler(IRiskCriteriaQueryRepository riskCriteriaRepository, IMapper mapper)
        {
            _riskCriteriaRepository = riskCriteriaRepository ?? throw new ArgumentNullException(nameof(riskCriteriaRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }



        public async Task<RiskCriteriaListPagingDTO> Handle(GetRiskCriteriaListQuery request, CancellationToken cancellationToken)
        {

            (long, IEnumerable<CompositeRiskCriteria>) result = await _riskCriteriaRepository.GetAll(request.pageSize, request.pageNumber, request.searchTerm);

            var riskCriteriaList = _mapper.Map<List<RiskCriteriaDTO>>(result.Item2);

            return new RiskCriteriaListPagingDTO { Items = riskCriteriaList, TotalCount = result.Item1 };
        }
    }
}

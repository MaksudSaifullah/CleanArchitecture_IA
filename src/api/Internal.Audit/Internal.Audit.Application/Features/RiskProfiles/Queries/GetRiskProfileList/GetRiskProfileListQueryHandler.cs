using AutoMapper;
using Internal.Audit.Application.Contracts.Persistent.RiskProfiles;
using Internal.Audit.Domain.CompositeEntities;
using MediatR;

namespace Internal.Audit.Application.Features.RiskProfiles.Queries.GetRiskProfileList
{
    public class GetRiskProfileListQueryHandler : IRequestHandler<GetRiskProfileListQuery, RiskProfileListPagingDTO>
    {
        private readonly IRiskProfileQueryRepository _riskProfileRepository;
        private readonly IMapper _mapper;

        public GetRiskProfileListQueryHandler(IRiskProfileQueryRepository riskProfileRepository, IMapper mapper)
        {
            _riskProfileRepository = riskProfileRepository ?? throw new ArgumentNullException(nameof(riskProfileRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<RiskProfileListPagingDTO> Handle(GetRiskProfileListQuery request, CancellationToken cancellationToken)
        {
            (long, IEnumerable<CompositeRiskProfile>) result = await _riskProfileRepository.GetAll(request.pageSize, request.pageNumber, request.searchTerm);

            var riskProfileList = _mapper.Map<List<RiskProfileDTO>>(result.Item2);

            return new RiskProfileListPagingDTO { Items = riskProfileList, TotalCount = result.Item1 };
        }
    }
}

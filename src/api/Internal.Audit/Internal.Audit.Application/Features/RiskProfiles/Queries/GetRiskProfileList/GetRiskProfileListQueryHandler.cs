using AutoMapper;
using Internal.Audit.Application.Contracts.Persistent.RiskProfiles;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        //public async Task<List<RiskProfileDTO>> Handle(GetRiskProfileListQuery request, CancellationToken cancellationToken)
        //{
        //    var riskProfiles = await _riskProfileRepository.GetAll();
        //    return _mapper.Map<List<RiskProfileDTO>>(riskProfiles);
        //}

        public async Task<RiskProfileListPagingDTO> Handle(GetRiskProfileListQuery request, CancellationToken cancellationToken)
        {
            var (count, result) = await _riskProfileRepository.GetAll(request.pageSize, request.pageNumber);

            var riskProfileList = _mapper.Map<IEnumerable<RiskProfileDTO>>(result).ToList();

            return new RiskProfileListPagingDTO { Items = riskProfileList, TotalCount = count };
        }
    }
}

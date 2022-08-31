using AutoMapper;
using Internal.Audit.Application.Contracts.Persistent.RiskAssesmentConsolidateDatas;
using MediatR;

namespace Internal.Audit.Application.Features.RiskAssesmentConsolidateDatas.Queries;

public class RiskConsolidateDataGetQueryHandler : IRequestHandler<RiskConsolidateDataGetQuery, IEnumerable<RiskConsolidateDataGetQueryResponseDTO>>
{
    private readonly IRiskAssesmentConsolidateDataQueryrepository _repositoryQuery;
    private readonly IMapper _mapper;

    public RiskConsolidateDataGetQueryHandler(IRiskAssesmentConsolidateDataQueryrepository repositoryQuery,
 IMapper mapper)
    {
        _repositoryQuery = repositoryQuery ?? throw new ArgumentNullException(nameof(repositoryQuery));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
    }

    public async Task<IEnumerable<RiskConsolidateDataGetQueryResponseDTO>> Handle(RiskConsolidateDataGetQuery request, CancellationToken cancellationToken)
    {
        var result = await _repositoryQuery.GetAllAsync(request.riskAssesmentId,request.countryId,request.pageNumber,request.pageSize);      
        return _mapper.Map<IEnumerable<RiskConsolidateDataGetQueryResponseDTO>>(result).ToList();
    }


}

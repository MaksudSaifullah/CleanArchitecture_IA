using AutoMapper;
using Internal.Audit.Application.Contracts.Persistent.AuditFeatures;
using MediatR;

namespace Internal.Audit.Application.Features.AuditFeature.Queries.GetFeatureList;
public class GetAuditFeatureListQueryHandler : IRequestHandler<GetAuditFeatureListQuery, List<GetAuditFeatureListResponseDTO>>
{
    private readonly IAuditFeatureQueryRepository _featureRepository;
    
    private readonly IMapper _mapper;

    public GetAuditFeatureListQueryHandler(IAuditFeatureQueryRepository featureRepository, IMapper mapper)
    {
        _featureRepository = featureRepository;
        _mapper = mapper;
    }

    public async Task<List<GetAuditFeatureListResponseDTO>> Handle(GetAuditFeatureListQuery request, CancellationToken cancellationToken)
    {
        var featureList = await _featureRepository.GetAll();
        return _mapper.Map<List<GetAuditFeatureListResponseDTO>>(featureList);
    }
}
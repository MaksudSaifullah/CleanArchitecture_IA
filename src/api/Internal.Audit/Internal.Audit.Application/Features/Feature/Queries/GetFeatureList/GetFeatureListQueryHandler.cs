using AutoMapper;
using Internal.Audit.Application.Contracts.Persistent.Features;
using MediatR;

namespace Internal.Audit.Application.Features.Feature.Queries.GetFeatureList;
public class GetFeatureListQueryHandler : IRequestHandler<GetFeatureListQuery, List<GetFeatureListResponseDTO>>
{
    private readonly IFeatureQueryRepository _featureRepository;
    
    private readonly IMapper _mapper;

    public GetFeatureListQueryHandler(IFeatureQueryRepository featureRepository, IMapper mapper)
    {
        _featureRepository = featureRepository;
        _mapper = mapper;
    }

    public async Task<List<GetFeatureListResponseDTO>> Handle(GetFeatureListQuery request, CancellationToken cancellationToken)
    {
        var featureList = await _featureRepository.GetAll();
        return _mapper.Map<List<GetFeatureListResponseDTO>>(featureList);
    }
}
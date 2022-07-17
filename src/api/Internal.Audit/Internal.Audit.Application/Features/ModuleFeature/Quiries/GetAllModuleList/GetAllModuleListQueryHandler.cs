using AutoMapper;
using Internal.Audit.Application.Contracts.Persistent.ModuleFeature;
using MediatR;

namespace Internal.Audit.Application.Features.ModuleFeature.Quiries.GetAllModuleList;

public class GetAllModuleListQueryHandler : IRequestHandler<GetAllModuleListQuery, IEnumerable<GetAllModuleListResponseDTO>>
{
    private readonly IModuleFeatureQueryRepository _moduleFeatureRepository;
    private readonly IMapper _mapper;

    public GetAllModuleListQueryHandler(IModuleFeatureQueryRepository moduleFeatureRepository, IMapper mapper)
    {
        _moduleFeatureRepository = moduleFeatureRepository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<GetAllModuleListResponseDTO>> Handle(GetAllModuleListQuery request, CancellationToken cancellationToken)
    {
        var moduleFeatureList = await _moduleFeatureRepository.GetAllModuleFeatureList(request.featureId);
        return _mapper.Map<IEnumerable<GetAllModuleListResponseDTO>>(moduleFeatureList);

    }
}

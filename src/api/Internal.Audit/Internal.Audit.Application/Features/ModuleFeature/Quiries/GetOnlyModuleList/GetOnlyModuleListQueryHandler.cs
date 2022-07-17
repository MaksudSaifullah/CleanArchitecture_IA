using AutoMapper;
using Internal.Audit.Application.Contracts.Persistent.ModuleFeature;
using MediatR;

namespace Internal.Audit.Application.Features.ModuleFeature.Quiries.GetOnlyModuleList;

public class GetOnlyModuleListQueryHandler : IRequestHandler<GetOnlyModuleListQuery, IEnumerable<GetOnlyModuleListResponseDTO>>
{
    private readonly IModuleFeatureQueryRepository _moduleFeatureRepository;
    private readonly IMapper _mapper;

    public GetOnlyModuleListQueryHandler(IModuleFeatureQueryRepository moduleFeatureRepository, IMapper mapper)
    {
        _moduleFeatureRepository = moduleFeatureRepository;
        _mapper = mapper;
    }
    public async Task<IEnumerable<GetOnlyModuleListResponseDTO>> Handle(GetOnlyModuleListQuery request, CancellationToken cancellationToken)
    {
        var moduleFeatureList = await _moduleFeatureRepository.GetOnlyModuleList();
        return _mapper.Map<IEnumerable<GetOnlyModuleListResponseDTO>>(moduleFeatureList);
    }
}

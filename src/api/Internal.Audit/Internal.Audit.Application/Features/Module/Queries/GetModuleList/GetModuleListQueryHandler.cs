using AutoMapper;
using Internal.Audit.Application.Contracts.Persistent.Modules;
using MediatR;


namespace Internal.Audit.Application.Features.Module.Queries.GetModuleList;
public class GetModuleListQueryHandler : IRequestHandler<GetModuleListQuery, List<GetModuleListResponseDTO>>
{
    //private readonly IDesignationQueryRepository _designationRepository;
    private readonly IModuleQueryRepository _moduleRepository;
    
    private readonly IMapper _mapper;

    public GetModuleListQueryHandler(IModuleQueryRepository moduleRepository, IMapper mapper)
    {
        _moduleRepository = moduleRepository;
        _mapper = mapper;
    }

    public async Task<List<GetModuleListResponseDTO>> Handle(GetModuleListQuery request, CancellationToken cancellationToken)
    {
        var moduleList = await _moduleRepository.GetAll();
        return _mapper.Map<List<GetModuleListResponseDTO>>(moduleList);
    }
}
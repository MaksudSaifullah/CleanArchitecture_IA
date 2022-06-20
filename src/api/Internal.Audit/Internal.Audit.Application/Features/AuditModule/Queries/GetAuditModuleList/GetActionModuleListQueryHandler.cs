using AutoMapper;
using Internal.Audit.Application.Contracts.Persistent.AuditModules;
using MediatR;


namespace Internal.Audit.Application.Features.Module.Queries.GetModuleList;
public class GetActionModuleListQueryHandler : IRequestHandler<GetActionModuleListQuery, List<GetActionModuleListResponseDTO>>
{
    //private readonly IDesignationQueryRepository _designationRepository;
    private readonly IAuditModuleQueryRepository _moduleRepository;
    
    private readonly IMapper _mapper;

    public GetActionModuleListQueryHandler(IAuditModuleQueryRepository moduleRepository, IMapper mapper)
    {
        _moduleRepository = moduleRepository;
        _mapper = mapper;
    }

    public async Task<List<GetActionModuleListResponseDTO>> Handle(GetActionModuleListQuery request, CancellationToken cancellationToken)
    {
        var moduleList = await _moduleRepository.GetAll();
        return _mapper.Map<List<GetActionModuleListResponseDTO>>(moduleList);
    }
}
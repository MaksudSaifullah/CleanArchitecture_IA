using AutoMapper;
using Internal.Audit.Application.Contracts.Persistent.AuditActions;
using MediatR;

namespace Internal.Audit.Application.Features.AuditAction.Queries.GetActionList;
public class GetAuditActionListQueryHandler : IRequestHandler<GetAuditActionListQuery, List<GetAuditActionListResponseDTO>>
{
    //private readonly IDesignationQueryRepository _designationRepository;
    private readonly IAuditActionQueryRepository _actionRepository;

    private readonly IMapper _mapper;

    public GetAuditActionListQueryHandler(IAuditActionQueryRepository actionRepository, IMapper mapper)
    {
        _actionRepository = actionRepository;
        _mapper = mapper;
    }

    public async Task<List<GetAuditActionListResponseDTO>> Handle(GetAuditActionListQuery request, CancellationToken cancellationToken)
    {
        var actionList = await _actionRepository.GetAll();
        return _mapper.Map<List<GetAuditActionListResponseDTO>>(actionList);
    }
}
using AutoMapper;
using Internal.Audit.Application.Contracts.Persistent.Actions;
using MediatR;

namespace Internal.Audit.Application.Features.Action.Queries.GetActionList;
public class GetActionListQueryHandler : IRequestHandler<GetActionListQuery, List<GetActionListResponseDTO>>
{
    //private readonly IDesignationQueryRepository _designationRepository;
    private readonly IActionQueryRepository _actionRepository;

    private readonly IMapper _mapper;

    public GetActionListQueryHandler(IActionQueryRepository actionRepository, IMapper mapper)
    {
        _actionRepository = actionRepository;
        _mapper = mapper;
    }

    public async Task<List<GetActionListResponseDTO>> Handle(GetActionListQuery request, CancellationToken cancellationToken)
    {
        var actionList = await _actionRepository.GetAll();
        return _mapper.Map<List<GetActionListResponseDTO>>(actionList);
    }
}
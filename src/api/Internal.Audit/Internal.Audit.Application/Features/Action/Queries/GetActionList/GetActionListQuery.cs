using MediatR;

namespace Internal.Audit.Application.Features.Action.Queries.GetActionList;
public class GetActionListQuery : IRequest<List<GetActionListResponseDTO>>
{
}
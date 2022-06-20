using MediatR;

namespace Internal.Audit.Application.Features.Action.Queries.GetActionList;
public class GetAuditActionListQuery : IRequest<List<GetAuditActionListResponseDTO>>
{
}
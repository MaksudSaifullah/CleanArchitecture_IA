using MediatR;

namespace Internal.Audit.Application.Features.AuditAction.Queries.GetActionList;
public class GetAuditActionListQuery : IRequest<List<GetAuditActionListResponseDTO>>
{
}
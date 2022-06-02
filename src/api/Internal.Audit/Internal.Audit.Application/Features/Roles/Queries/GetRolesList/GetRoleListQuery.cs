using Internal.Audit.Application.Features.Roles.Queries.GetRolesList;
using MediatR;

namespace Internal.Audit.Application.Features.Roles.Queries.GetRolesList;
public class GetRoleListQuery : IRequest<List<RoleDTO>>
{
}
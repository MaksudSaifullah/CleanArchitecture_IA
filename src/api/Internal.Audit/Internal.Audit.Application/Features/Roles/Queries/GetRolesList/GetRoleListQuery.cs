using Internal.Audit.Application.Features.Roles.Queries.GetRolesList;
using MediatR;

namespace Internal.Audit.Application.Features.Roles.Queries.GetRolesList;
public class GetRoleListQuery : IRequest<RoleListPagingDTO>
{
    public int pageSize { get; set; }
    public int pageNumber { get; set; }
    public dynamic searchTerm { get; set; }
}
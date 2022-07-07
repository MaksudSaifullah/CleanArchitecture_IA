using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internal.Audit.Application.Features.ModulewiseRolePrivilege.Quiries.GetModilewiseRoleByRoleIdList
{
    public class GetModulewiseRolePrivilegeByRoleIdListQuery : IRequest<GetModulewiseRolePrivilegeByRoleIdListPagingDTO>
    {
        public int pageSize { get; set; }
        public int pageNumber { get; set; }
        public Guid roleId { get; set; }
        public dynamic searchTerm { get; set; }
    }

}

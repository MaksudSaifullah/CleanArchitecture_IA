using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internal.Audit.Application.Features.ModulewiseRolePrivilege.Quiries.GetModilewiseRoleByRoleIdList
{
    public class GetModulewiseRolePrivilegeByRoleIdListPagingDTO
    {
        public IEnumerable<GetModulewiseRolePrivilegeByRoleIdListResponseDTO> Items { get; set; } = null!;
        public long TotalCount { get; set; }
    }
}

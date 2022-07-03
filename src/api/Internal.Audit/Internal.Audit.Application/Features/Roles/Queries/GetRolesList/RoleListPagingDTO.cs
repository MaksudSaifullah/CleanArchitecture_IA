using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internal.Audit.Application.Features.Roles.Queries.GetRolesList
{
    public record RoleListPagingDTO
    {
        public IEnumerable<RoleDTO> Items { get; set; } = null!;
        public long TotalCount { get; set; }
    }
}

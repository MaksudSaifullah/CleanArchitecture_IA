using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internal.Audit.Application.Features.UserList.Queries.GetUserList
{
    public record UserListWithPagingInfoDTO
    {
        public IEnumerable<GetUserListResponseDTO> UserList { get; set; } = null!;
        public long TotalCount { get; set; }
    }
}

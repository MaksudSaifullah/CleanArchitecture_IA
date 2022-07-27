using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internal.Audit.Application.Features.EmailConfig.Queries.GetEmailConfigList
{
    public record EmailConfigListPagingDTO
    {
        public IEnumerable<GetEmailConfigListResponseDTO> Items { get; set; } = null!;
        public long TotalCount { get; set; }
    }
}

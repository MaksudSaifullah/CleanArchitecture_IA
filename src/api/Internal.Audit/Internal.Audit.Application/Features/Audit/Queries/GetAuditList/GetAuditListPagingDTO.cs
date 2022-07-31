using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internal.Audit.Application.Features.Audit.Queries.GetAuditList
{
    public record GetAuditListPagingDTO
    {
        public IEnumerable<GetAuditListResponseDTO> Items { get; set; } = null!;
        public long TotalCount { get; set; }
    }
}

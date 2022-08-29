using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internal.Audit.Application.Features.Audit.Queries.GetAuditType
{
    public class AuditTypePagingDTO
    {
        public IEnumerable<GetAuditTypeResponseDTO> Items { get; set; } = null!;
        public long TotalCount { get; set; }
    }
}

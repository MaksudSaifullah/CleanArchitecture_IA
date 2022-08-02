using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internal.Audit.Application.Features.Audit.Queries.GetAuditPlanCodeList
{
    public class AuditPlanCodePagingDTO
    {
        public IEnumerable<GetAuditPlanCodeListResponseDTO> Items { get; set; } = null!;
        public long TotalCount { get; set; }
    }
}

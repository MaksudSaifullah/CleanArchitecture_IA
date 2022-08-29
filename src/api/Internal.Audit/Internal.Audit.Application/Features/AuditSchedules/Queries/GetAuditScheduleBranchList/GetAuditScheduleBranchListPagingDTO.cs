using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internal.Audit.Application.Features.AuditSchedules.Queries.GetAuditScheduleBranchList
{
    public record GetAuditScheduleBranchListPagingDTO
    {
        public IEnumerable<GetAuditScheduleBranchListResponseDTO> Items { get; set; } = null!;
        public long TotalCount { get; set; }
    }
}

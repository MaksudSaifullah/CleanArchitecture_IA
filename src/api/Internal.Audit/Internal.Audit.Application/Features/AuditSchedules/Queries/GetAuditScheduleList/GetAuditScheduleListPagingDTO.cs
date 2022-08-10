using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internal.Audit.Application.Features.AuditSchedules.Queries.GetAuditScheduleList
{
    public record GetAuditScheduleListPagingDTO
    {
        public IEnumerable<GetAuditScheduleListResponseDTO> Items { get; set; } = null!;
        public long TotalCount { get; set; }
    }
}

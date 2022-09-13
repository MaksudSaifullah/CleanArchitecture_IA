using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internal.Audit.Application.Features.AuditScheduleConfigurationsOwner.Queries.GetOwnerList
{
    public record GetOwnerListPagingDTO
    {
        public IEnumerable<GetOwnerListResponseDTO> Items { get; set; } = null!;
        public long TotalCount { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internal.Audit.Application.Features.AuditScheduleConfigurationsOwner.Queries.GetOwnerList
{
    public record GetOwnerListResponseDTO
    {
        public Guid AuditScheduleId { get; set; }
        public string BranchName { get; set; }
        public string UserName { get; set; }
    }
}

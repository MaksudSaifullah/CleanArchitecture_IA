using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internal.Audit.Application.Features.AuditSchedules.Queries.GetAuditScheduleBranchList
{
    public record GetAuditScheduleBranchListResponseDTO
    {
        public Guid AuditScheduleId { get; set; }
        public Guid BranchId { get; set; }
        public string BranchName { get; set; }
        public string CountryName { get; set; }
    }
}

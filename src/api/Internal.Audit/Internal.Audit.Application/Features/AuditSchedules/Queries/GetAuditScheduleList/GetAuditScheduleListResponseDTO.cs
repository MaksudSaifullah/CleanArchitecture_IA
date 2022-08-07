using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internal.Audit.Application.Features.AuditSchedules.Queries.GetAuditScheduleList;
public record GetAuditScheduleListResponseDTO
{
    public Guid Id { get; set; }
    public string Country { get; set; }
    public string Approver { get; set; }
    public string TeamLeader { get; set; }
    public string Auditor { get; set; }
    public string ExecutionStatus { get; set; }
    public string ScheduleStatus { get; set; }
    public DateTime ScheduleStartDate { get; set; }
    public DateTime ScheduleEndDate { get; set; }
    public DateTime CreatedOn { get; set; }
}

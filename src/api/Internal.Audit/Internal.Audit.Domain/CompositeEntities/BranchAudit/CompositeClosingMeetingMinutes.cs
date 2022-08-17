using Internal.Audit.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internal.Audit.Domain.CompositeEntities.BranchAudit;

public class CompositeClosingMeetingMinutes : EntityBase
{
    public string? MeetingMinutesCode { get; set; }

    public Guid AuditScheduleId { get; set; }

    public Guid BranchId { get; set; }

    public DateTime MeetingMinutesDate { get; set; }

    public string? MeetingMinutesName { get; set; }

    public string? AuditOn { get; set; }

    public string? MeetingHeld { get; set; }

    public Guid PreparedByUserId { get; set; }

    public Guid AgreedByUserId { get; set; }

}

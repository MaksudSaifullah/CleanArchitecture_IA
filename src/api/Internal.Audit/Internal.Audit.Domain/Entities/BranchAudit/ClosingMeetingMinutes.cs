
using Internal.Audit.Domain.Common;
using Internal.Audit.Domain.Entities.Security;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internal.Audit.Domain.Entities.BranchAudit;

[Table("ClosingMeetingMinutes", Schema = "BranchAudit")]
public class ClosingMeetingMinutes : EntityBase
{
    [Required]
    [MaxLength(100)]
    public string? MeetingMinutesCode { get; set; }

    [Required]
    public Guid AuditScheduleId { get; set; }

    [Required]
    public Guid BranchId { get; set; }

    [Required]
    public DateTime MeetingMinutesDate { get; set; }

    [Required]
    [MaxLength(300)]
    public string? MeetingMinutesName { get; set; }

    [Required]
    [MaxLength(300)]
    public string? AuditOn { get; set; }

    [Required]
    [MaxLength(300)]
    public string? MeetingHeld { get; set; }

    [Required]
    public Guid PreparedByUserId { get; set; }

    [Required]
    public Guid AgreedByUserId { get; set; }

    public virtual ICollection<ClosingMeetingPresent> UserPresents { get; set; } = null!;
    public virtual ICollection<ClosingMeetingApology> UserApologies { get; set; } = null!;
    public virtual ICollection<ClosingMeetingSubject> MeetingMinutesSubjects { get; set; } = null!;

}

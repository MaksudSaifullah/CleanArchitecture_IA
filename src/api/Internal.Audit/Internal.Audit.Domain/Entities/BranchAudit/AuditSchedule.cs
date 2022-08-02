using Internal.Audit.Domain.Common;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Internal.Audit.Domain.Entities.BranchAudit;
[Table("AuditSchedule", Schema = "BranchAudit")]
public class AuditSchedule : EntityBase
{
    [Required]
    public Guid AuditPlanId { get; set; }
    [Required]
    public DateTime ScheduleStartDate { get; set; }

    [Required]
    public DateTime ScheduleEndDate { get; set; }
   
    [ForeignKey("AuditPlanId")]
    public virtual AuditPlan AuditPlan { get; set; } = null!;
    public virtual ICollection<AuditScheduleParticipants> AuditScheduleParticipants { get; set; } = null!;
    public virtual ICollection<AuditScheduleBranch> AuditScheduleBranch { get; set; } = null!;

}

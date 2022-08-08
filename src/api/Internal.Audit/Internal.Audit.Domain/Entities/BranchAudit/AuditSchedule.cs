using Internal.Audit.Domain.Common;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Internal.Audit.Domain.Entities.BranchAudit;
[Table("AuditSchedule", Schema = "BranchAudit")]
public class AuditSchedule : EntityBase
{
    //[Required]
    //public Guid AuditPlanId { get; set; }

    [Required]
    public Guid AuditCreationId { get; set; }
    [Required]
    public DateTime ScheduleStartDate { get; set; }

    [Required]
    public DateTime ScheduleEndDate { get; set; }
   
    [MaxLength(10)]
    public string? ScheduleId { get; set; }

    public int ScheduleState { get; set; } = -1;

    //[ForeignKey("AuditPlanId")]
    //public virtual AuditPlan AuditPlan { get; set; } = null!;

    [ForeignKey("AuditCreationId")]
    public virtual AuditCreation AuditCreation { get; set; } = null!;
    public virtual ICollection<AuditScheduleParticipants> AuditScheduleParticipants { get; set; } = null!;
    public virtual ICollection<AuditScheduleBranch> AuditScheduleBranch { get; set; } = null!;

}

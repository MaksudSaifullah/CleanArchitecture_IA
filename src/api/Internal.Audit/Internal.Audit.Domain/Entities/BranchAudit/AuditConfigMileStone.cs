using Internal.Audit.Domain.Common;
using Internal.Audit.Domain.Entities.Config;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Internal.Audit.Domain.Entities.BranchAudit;
[Table("AuditConfigMileStone", Schema = "BranchAudit")]
public class AuditConfigMileStone : EntityBase
{
    [Required]
    public Guid AuditScheduleId { get; set; }   
    public int CommonValueAuditConfigMilestoneId { get; set; }   
    public DateTime? SetDate { get; set; }
    [ForeignKey("AuditScheduleId")]
    public virtual AuditSchedule AuditSchedule { get; set; } = null!;
    [NotMapped]
    public virtual CommonValueAndType CommonValue { get; set; } = null!;
}

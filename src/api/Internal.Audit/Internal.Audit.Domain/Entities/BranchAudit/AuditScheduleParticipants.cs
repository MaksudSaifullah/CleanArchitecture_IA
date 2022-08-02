using Internal.Audit.Domain.Common;
using Internal.Audit.Domain.Entities.Config;
using Internal.Audit.Domain.Entities.Security;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internal.Audit.Domain.Entities.BranchAudit;
[Table("AuditScheduleParticipants", Schema = "BranchAudit")]
public class AuditScheduleParticipants : EntityBase
{
    [Required]
    public Guid AuditScheduleId { get; set; }
    [Required]
    public Guid UserId { get; set; }
    //[Required]
    //public int CommonValueParticipantId { get; set; }
    public int CommonValueParticipantId { get; set; }
    [ForeignKey("AuditScheduleId")]
    public virtual AuditSchedule AuditSchedule { get; set; } = null!;
    [ForeignKey("UserId")]
    public virtual User User { get; set; } = null!;
    [NotMapped]
    public virtual CommonValueAndType CommonValueAndTypeParticipant { get; set; } = null!;
}

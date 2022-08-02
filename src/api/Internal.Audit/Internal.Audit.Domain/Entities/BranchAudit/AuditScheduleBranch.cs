using Internal.Audit.Domain.Common;
using Internal.Audit.Domain.Entities.security;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internal.Audit.Domain.Entities.BranchAudit;
[Table("AuditScheduleBranch", Schema = "BranchAudit")]
public class AuditScheduleBranch : EntityBase
{
    [Required]
    public Guid AuditScheduleId { get; set; }
    [Required]
    public Guid BranchId { get; set; }
    [ForeignKey("AuditScheduleId")]
    public virtual AuditSchedule AuditSchedule { get; set; } = null!;
    [NotMapped]
    public virtual Branch Branch { get; set; } = null!;
}

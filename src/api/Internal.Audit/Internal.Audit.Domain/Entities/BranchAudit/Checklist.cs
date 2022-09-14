using Internal.Audit.Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internal.Audit.Domain.Entities.BranchAudit;

[Table("Checklists", Schema = "BranchAudit")]
public class Checklist : EntityBase
{
    [Required]
    [MaxLength(100)]
    public string? ChecklistCode { get; set; }

    [Required]
    public Guid AuditScheduleId { get; set; }

    [Required]
    public Guid AuditScheduleBranchId { get; set; }

    [Required]
    public Guid RegionId { get; set; }

    [Required]
    public DateTime OpeningDate { get; set; }

    [Required]
    public DateTime DisbursementDate { get; set; }

    [Required]
    [MaxLength(300)]
    public string? BranchManagerName { get; set; }


    [Required]
    public DateTime BMJoiningDate { get; set; }

    [Required]
    public DateTime AuditDate { get; set; }

    [Required]
    [MaxLength(300)]
    public string? AuditOn { get; set; }

    [Required]
    public DateTime LastAuditFromDate { get; set; }

    [Required]
    public DateTime LastAuditToDate { get; set; }

    [Required]
    [DefaultValue("0")]
    public bool IsDraft { get; set; }

    public virtual ICollection<ChecklistTopic> ChecklistTopicHeads { get; set; } = null!;

}

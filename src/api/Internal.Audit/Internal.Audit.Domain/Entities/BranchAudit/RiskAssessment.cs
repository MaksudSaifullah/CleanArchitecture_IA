using Internal.Audit.Domain.Common;
using Internal.Audit.Domain.Entities.Config;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internal.Audit.Domain.Entities.BranchAudit;

[Table("RiskAssessment", Schema = "BranchAudit")]
public class RiskAssessment : EntityBase
{
    [Required]
    public Guid CountryId { get; set; }

    [Required]
    public Guid AuditTypeId { get; set; }

    [Required]
    [MaxLength(60)]
    public string AssessmentCode { get; set; } = null!;

    [Required]
    public DateTime EffectiveFrom { get; set; }

    [Required]
    public DateTime EffectiveTo { get; set; }

    [ForeignKey("CountryId")]
    public virtual Country Country { get; set; } = null!;

    [ForeignKey("AuditTypeId")]
    public virtual CommonValueAndType CommonValueAuditType { get; set; }
}


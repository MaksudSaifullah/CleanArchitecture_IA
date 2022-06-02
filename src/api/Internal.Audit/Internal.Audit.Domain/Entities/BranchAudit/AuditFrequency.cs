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

[Table("AuditFrequency", Schema = "BranchAudit")]
public class AuditFrequency : EntityBase
{
    [Required]
    public Guid CountryId { get; set; }

    [Required]
    public Guid AuditScoreId { get; set; }

    [Required]
    public Guid RatingTypeId { get; set; }

    [Required]
    public Guid AuditFrequencyTypeId { get; set; }


    [ForeignKey("CountryId")]
    public virtual Country Country { get; set; } = null!;

    [ForeignKey("AuditScoreId")]
    public virtual AuditScore AuditScore { get; set; } = null!;

    [ForeignKey("RatingTypeId")]
    public virtual RatingType RatingType { get; set; } = null!;

    [ForeignKey("AuditFrequencyTypeId")]
    public virtual AuditFrequencyType AuditFrequencyType { get; set; } = null!;

}

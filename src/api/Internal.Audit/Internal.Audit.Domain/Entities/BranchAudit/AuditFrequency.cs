using Internal.Audit.Domain.Common;
using Internal.Audit.Domain.Entities.Config;
using System;
using System.ComponentModel;
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

    [Required]
    public DateTime EffectiveFrom { get; set; }

    [Required]
    public DateTime EffectiveTo { get; set; }

    [ForeignKey("CountryId")]
    public virtual Country Country { get; set; } = null!;

    
    public virtual CommonValueAndType CommonValueAuditScoreType { get; set; }
    public virtual CommonValueAndType CommonValueRatingType { get; set; }
    public virtual CommonValueAndType CommonValueAuditFrequencyType { get; set; }

}

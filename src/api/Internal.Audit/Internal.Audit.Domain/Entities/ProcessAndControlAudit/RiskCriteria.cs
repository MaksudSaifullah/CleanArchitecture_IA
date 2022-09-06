using Internal.Audit.Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internal.Audit.Domain.Entities.ProcessAndControlAudit;

[Table("RiskCriteria", Schema = "ProcessAndControlAudit")]
public class RiskCriteria : EntityBase
{
    [Required]
    public Guid CountryId { get; set; }

    [Required]
    public string Name { get; set; }

    [Required]
    public decimal Weight { get; set; }

    [Required]
    public DateTime EffectiveFrom { get; set; }

    [Required]
    public DateTime EffectiveTo { get; set; }

    [MaxLength(300)]
    public string? Description { get; set; } = null!;

    [ForeignKey("CountryId")]
    public virtual Country Country { get; set; } = null!;

    //public virtual CommonValueAndType CommonValueRatingType { get; set; }
    //public virtual CommonValueAndType CommonValueRiskCriteriaType { get; set; }

}


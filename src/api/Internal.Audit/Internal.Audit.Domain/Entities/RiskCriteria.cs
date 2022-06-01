using Internal.Audit.Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internal.Audit.Domain.Entities;


[Table("RiskCriteria", Schema = "")]
public class RiskCriteria : EntityBase
{
    [Required]
    public Guid CountryId { get; set; }

    [Required]
    public Guid RatingTypeId { get; set; }

    [Required]
    public Guid RiskCriteriaTypeId { get; set; }

    [Required]
    public Guid AuditTypeId { get; set; }

    [Required]
    public string Name { get; set; }

    [Required]
    public decimal Weight { get; set; }

    [Required]
    public DateTime EffectiveFrom { get; set; }
    [Required]
    public DateTime EffectiveTo { get; set; }


    [Required]
    public decimal MinimumValue { get; set; }
    [Required]
    public decimal MaximumValue { get; set; }

    [Required]
    public decimal Score { get; set; }



    [Required]
    [MaxLength(300)]
    public string Description { get; set; }

    [ForeignKey("CountryId")]
    public virtual Country Country { get; set; } = null!;

    [ForeignKey("RatingTypeId")]
    public virtual RatingType RatingType { get; set; } = null!;

    [ForeignKey("RiskCriteriaTypeId")]
    public virtual RiskCriteriaType RiskCriteriaType { get; set; } = null!;

/*    [ForeignKey("AuditTypeId")]
    public virtual AuditType AuditType { get; set; } = null!;*/
}
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


[Table("RiskCriteria", Schema = "BranchAudit")]
public class RiskCriteria : EntityBase
{
    [Required]

    public Guid CountryId { get; set; }

    [Required]
    public Guid RatingTypeId { get; set; }

    [Required]
    public Guid RiskCriteriaTypeId { get; set; }

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

    public string CountryName { get; set; } = null!;

    [ForeignKey("CountryId")]
    public virtual Country Country { get; set; } = null!;
   
    public virtual CommonValueAndType CommonValueRatingType { get; set; }
    public virtual CommonValueAndType CommonValueRiskCriteriaType { get; set; }

  
}
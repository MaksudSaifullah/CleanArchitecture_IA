using Internal.Audit.Domain.Common;
using Internal.Audit.Domain.Entities.Config;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Internal.Audit.Domain.Entities.Common;

[Table("RiskProfile", Schema = "Common")]
public class RiskProfile : EntityBase
{
    [Required]
    public Guid LikelihoodTypeId { get; set; }
    [Required]
    public Guid ImpactTypeId { get; set; }
    [Required]
    public Guid RatingTypeId { get; set; }
    [Required]
    public DateTime EffectiveFrom { get; set; }
    [Required]
    public DateTime EffectiveTo { get; set; }
    [Required]
    public string Description { get; set; } = null!;
    [Required]
    [DefaultValue("1")]
    public bool IsActive { get; set; }

   
    public virtual CommonValueAndType CommonValueLikelihoodType { get; set; }   
    public virtual CommonValueAndType CommonValueImpactType { get; set; }   
    public virtual CommonValueAndType CommonValueRatingType { get; set; }    
}
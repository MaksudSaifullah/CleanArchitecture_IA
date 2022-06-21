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

    [ForeignKey("LikelihoodTypeId")]
    public virtual CommonValueAndType CommonValueLikelihoodType { get; set; } = null!;
    [ForeignKey("ImpactTypeId")]
    public virtual CommonValueAndType CommonValueImpactType { get; set; } = null!;
    [ForeignKey("RatingTypeId")]
    public virtual CommonValueAndType CommonValueRatingType { get; set; } = null!;    
}
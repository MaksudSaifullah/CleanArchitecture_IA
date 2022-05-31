using Internal.Audit.Domain.Common;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Internal.Audit.Domain.Entities;

[Table("RiskProfile", Schema = "")]
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
    public virtual LikelihoodType LikelihoodType { get; set; } = null!;
    [ForeignKey("ImpactTypeId")]
    public virtual ImpactType ImpactType { get; set; } = null!;
    [ForeignKey("RatingTypeId")]
    public virtual RatingType RatingType { get; set; } = null!;    
}
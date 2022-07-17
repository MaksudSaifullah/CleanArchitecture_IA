
using Internal.Audit.Domain.Common;

namespace Internal.Audit.Domain.CompositeEntities;
public class CompositeRiskProfile : EntityBase
{
    public Guid Id { get; set; }
    public Guid LikelihoodTypeId { get; set; }
    public string LikelihoodType { get; set; } = null!;
    public Guid ImpactTypeId { get; set; }
    public string ImpactType { get; set; } = null!;
    public Guid RatingTypeId { get; set; }
    public string RatingType { get; set; } = null!;
    public DateTime EffectiveFrom { get; set; }
    public DateTime EffectiveTo { get; set; }
    public string Description { get; set; } = null!;
    public bool IsActive { get; set; }
}


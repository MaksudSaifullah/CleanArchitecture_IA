using Internal.Audit.Domain.Common;

namespace Internal.Audit.Domain.CompositeEntities.BranchAudit;

public class CompositeQuestionnaire : EntityBase
{
    public Guid Id { get; set; }
    public Guid TopicHeadId { get; set; }
    public string? TopicHead { get; set; } = null!;
    public Guid CountryId { get; set; }
    public string? Country { get; set; } = null!;    
    public string Question { get; set; } = null!;
    public DateTime EffectiveFrom { get; set; }
    public DateTime EffectiveTo { get; set; }
    public bool IsActive { get; set; }
}
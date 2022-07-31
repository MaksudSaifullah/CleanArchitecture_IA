using Internal.Audit.Domain.Common;

namespace Internal.Audit.Domain.CompositeEntities.BranchAudit;
public class CompositeTestStep : EntityBase
{
    public Guid Id { get; set; }
    public Guid QuestionnaireId { get; set; }
    public string? Questionnaire { get; set; }
    public Guid TopicHeadId { get; set; }
    public string? TopicHead { get; set; } = null!;
    public Guid CountryId { get; set; }
    public string? Country { get; set; } = null!;
    public string TestStepDetails { get; set; } = null!;
    public DateTime EffectiveFrom { get; set; }
    public DateTime EffectiveTo { get; set; }
    
}
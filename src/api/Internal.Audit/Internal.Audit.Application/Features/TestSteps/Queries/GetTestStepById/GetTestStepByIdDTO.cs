namespace Internal.Audit.Application.Features.TestSteps.Queries.GetTestStepById;

public record GetTestStepByIdDTO
{
    public Guid Id { get; set; }
    public Guid QuestionnaireId { get; set; }
    public Guid CountryId { get; set; }
    public Guid TopicHeadId { get; set; }
    public string TestStepDetails { get; set; } = null!;
    public DateTime EffectiveFrom { get; set; }
    public DateTime EffectiveTo { get; set; }
}
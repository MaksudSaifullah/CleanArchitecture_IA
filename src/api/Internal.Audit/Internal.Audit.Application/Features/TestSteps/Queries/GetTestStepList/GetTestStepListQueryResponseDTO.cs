

namespace Internal.Audit.Application.Features.TestSteps.Queries.GetTestStepList;
public record GetTestStepListQueryResponseDTO
{
    public Guid Id { get; set; }
    public string Questionnaire { get; set; }
    public string TopicHead { get; set; }
    public string Country { get; set; }
    public string TestStepDetails { get; set; }
    public DateTime EffectiveFrom { get; set; }
    public DateTime EffectiveTo { get; set; }
    public string Description { get; set; } = null!;    
}

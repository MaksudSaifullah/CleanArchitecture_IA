
namespace Internal.Audit.Application.Features.Questionnnaires.Queries.GetQuestionnaireById;
public record GetQuestionnaireByIdDTO
{
    public Guid Id { get; set; }
    public Guid CountryId { get; set; }
    public Guid TopicHeadId { get; set; }
    public string Question { get; set; } = null!;
    public DateTime EffectiveFrom { get; set; }
    public DateTime EffectiveTo { get; set; }
    
    public bool IsActive { get; set; }
}
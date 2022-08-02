
namespace Internal.Audit.Application.Features.Questionnnaires.Queries.GetQuestionnaireByFilter;
public record GetQuestionnaireByFilterResponseDTO
{
    public Guid Id { get; set; }
    public Guid CountryId { get; set; }
    public Guid TopicHeadId { get; set; }
    public string Question { get; set; } = null!;
    public DateTime EffectiveFrom { get; set; }
    public DateTime EffectiveTo { get; set; }

    public bool IsActive { get; set; }
}

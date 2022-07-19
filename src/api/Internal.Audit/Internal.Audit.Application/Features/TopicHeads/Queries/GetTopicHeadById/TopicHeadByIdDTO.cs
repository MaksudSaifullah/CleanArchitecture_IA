
namespace Internal.Audit.Application.Features.TopicHeads.Queries.GetTopicHeadById;
public record TopicHeadByIdDTO
{
    public Guid Id { get; set; }
    public Guid CountryId { get; set; }
    public string Name { get; set; }
    public DateTime EffectiveFrom { get; set; }
    public DateTime EffectiveTo { get; set; }
    public string? Description { get; set; }
}
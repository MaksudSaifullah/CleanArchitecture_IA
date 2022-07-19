
namespace Internal.Audit.Application.Features.TopicHeads.Queries.GetTopicHeadList;
public record TopicHeadDTO
{
    public Guid Id { get; set; }
    public Guid CountryId { get; set; }
    public string Name { get; set; }
    public DateTime EffectiveFrom { get; set; }
    public DateTime EffectiveTo { get; set; }
    public string? Description { get; set; }
    public string? CountryName { get; set; }
}
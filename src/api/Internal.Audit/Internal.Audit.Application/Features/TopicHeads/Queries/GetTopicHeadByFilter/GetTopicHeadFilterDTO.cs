
namespace Internal.Audit.Application.Features.TopicHeads.Queries.GetTopicHeadByFilter;
public record GetTopicHeadFilterDTO
{
    public string FilterName { get; set; }
    public Guid FilterValue { get; set; }
}
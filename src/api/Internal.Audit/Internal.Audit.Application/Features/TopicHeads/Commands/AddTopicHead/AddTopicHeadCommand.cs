using MediatR;

namespace Internal.Audit.Application.Features.TopicHeads.Commands.AddTopicHead;
public class AddTopicHeadCommand : IRequest<AddTopicHeadResponseDTO>
{
    public Guid CountryId { get; set; }
    public string Name { get; set; }
    public DateTime EffectiveFrom { get; set; }
    public DateTime EffectiveTo { get; set; }
    public string? Description { get; set; } = null!;
}
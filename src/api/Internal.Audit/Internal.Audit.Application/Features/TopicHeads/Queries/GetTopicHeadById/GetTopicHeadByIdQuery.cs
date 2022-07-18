using MediatR;

namespace Internal.Audit.Application.Features.TopicHeads.Queries.GetTopicHeadById;
public record GetTopicHeadByIdQuery(Guid Id) : IRequest<TopicHeadByIdDTO>
{

}
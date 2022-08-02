using MediatR;


namespace Internal.Audit.Application.Features.TopicHeads.Queries.GetTopicHeadByFilter;
public record GetTopicHeadByFilterQuery(GetTopicHeadFilterDTO Filter) : IRequest<IEnumerable<GetTopicHeadByFilterResponseDTO>>
{

}

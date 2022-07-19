using MediatR;

namespace Internal.Audit.Application.Features.TopicHeads.Commands.DeleteTopicHead;

public class DeleteTopicHeadCommand : IRequest<DeleteTopicHeadResponseDTO>
{
    public Guid Id { get; set; }
    public DeleteTopicHeadCommand(Guid id)
    {
        Id = id;
    }
}
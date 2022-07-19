using Internal.Audit.Application.Common;

namespace Internal.Audit.Application.Features.TopicHeads.Commands.DeleteTopicHead;

public record DeleteTopicHeadResponseDTO : BaseResponseDTO
{
    public DeleteTopicHeadResponseDTO(Guid Id, bool Success, string Message) : base(Id, Success, Message)
    {
    }
}


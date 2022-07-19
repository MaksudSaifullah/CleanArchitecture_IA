using Internal.Audit.Application.Common;

namespace Internal.Audit.Application.Features.TopicHeads.Commands.UpdateTopicHead;
public record UpdateTopicHeadResponseDTO : BaseResponseDTO
{
    public UpdateTopicHeadResponseDTO(Guid Id, bool Success, string Message) : base(Id, Success, Message)
    {
    }
}

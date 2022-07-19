using Internal.Audit.Application.Common;


namespace Internal.Audit.Application.Features.TopicHeads.Commands.AddTopicHead;
public record AddTopicHeadResponseDTO : BaseResponseDTO
{
    public AddTopicHeadResponseDTO(Guid Id, bool Success, string Message) : base(Id, Success, Message)
    {
    }
}

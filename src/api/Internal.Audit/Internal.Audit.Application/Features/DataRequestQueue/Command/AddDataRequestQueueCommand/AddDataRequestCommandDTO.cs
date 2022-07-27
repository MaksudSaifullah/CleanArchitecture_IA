using Internal.Audit.Application.Common;

namespace Internal.Audit.Application.Features.DataRequestQueue.Command.AddDataRequestQueueCommand;

public record AddDataRequestCommandDTO : BaseResponseDTO
{
    public AddDataRequestCommandDTO(Guid Id, bool Success, string Message) : base(Id, Success, Message)
    {
    }
}

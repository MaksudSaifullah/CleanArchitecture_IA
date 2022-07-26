using Internal.Audit.Application.Common;

namespace Internal.Audit.Application.Features.DataPull.Commands.AddDataPullCommand;

public record AddDataPullCommandDTO : BaseResponseDTO
{
    public AddDataPullCommandDTO(Guid Id, bool Success, string Message) : base(Id, Success, Message)
    {
    }
}


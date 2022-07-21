using Internal.Audit.Application.Common;

namespace Internal.Audit.Application.Features.Documents.Commands.AddDocumentCommand;

public record AddDocumentCommandResponseDTO : BaseResponseDTO
{
    public AddDocumentCommandResponseDTO(Guid Id, bool Success, string Message) : base(Id, Success, Message)
    {
    }
}

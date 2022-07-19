using MediatR;

namespace Internal.Audit.Application.Features.Documents.Commands.AddDocumentCommand;

public class AddDocumentCommand:IRequest<AddDocumentCommandResponseDTO>
{
    public Guid DocumentSourceId { get; set; }
    public string Name { get; set; }
}

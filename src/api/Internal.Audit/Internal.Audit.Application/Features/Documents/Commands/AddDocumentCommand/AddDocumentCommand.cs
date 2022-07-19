using MediatR;
using Microsoft.AspNetCore.Http;

namespace Internal.Audit.Application.Features.Documents.Commands.AddDocumentCommand;

public class AddDocumentCommand:IRequest<AddDocumentCommandResponseDTO>
{
    public Guid DocumentSourceId { get; set; }
    public string DocumentSourceName { get; set; }
    public string Name { get; set; }
    public IFormFile File{ get; set; }
}

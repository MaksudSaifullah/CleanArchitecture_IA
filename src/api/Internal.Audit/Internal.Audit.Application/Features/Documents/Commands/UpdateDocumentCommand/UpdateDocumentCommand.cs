using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internal.Audit.Application.Features.Documents.Commands.UpdateDocumentCommand;

public class UpdateDocumentCommand : IRequest<UpdateDocumentCommandDTO>
{
    public Guid Id { get; set; }
    public string? Name { get; set; }
    public IFormFile? File { get; set; }
    public Guid? DocumentSourceId { get; set; }
    public string? DocumentSourceName { get; set; }
}

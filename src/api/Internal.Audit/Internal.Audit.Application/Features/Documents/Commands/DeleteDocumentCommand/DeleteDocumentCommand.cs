using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internal.Audit.Application.Features.Documents.Commands.DeleteDocumentCommand;

public record DeleteDocumentCommand(Guid Id):IRequest<DeleteDocumentCommandDTO>;


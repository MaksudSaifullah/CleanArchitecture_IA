using Internal.Audit.Application.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internal.Audit.Application.Features.Documents.Commands.UpdateDocumentCommand;

public record UpdateDocumentCommandDTO : BaseResponseDTO
{
    public UpdateDocumentCommandDTO(Guid Id, bool Success, string Message) : base(Id, Success, Message)
    {
    }
}

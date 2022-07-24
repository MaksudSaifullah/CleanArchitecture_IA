using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internal.Audit.Application.Features.Audit.Commands.DeleteAudit
{
    public class DeleteAuditCommand: IRequest<DeleteAuditResponseDTO>
    {
        public Guid Id { get; set; }
        public DeleteAuditCommand(Guid id)
        {
            Id = id;
        }
    }
}

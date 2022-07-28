using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internal.Audit.Application.Features.AuditFrequencies.Commands.DeleteAuditFrequency;
public class DeleteAuditFrequencyCommand : IRequest<DeleteAuditFrequencyResponseDTO>
  {
        public Guid Id { get; set; }
    public DeleteAuditFrequencyCommand(Guid id)
    {
        Id = id;
    }
  }

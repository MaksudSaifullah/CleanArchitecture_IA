using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internal.Audit.Application.Features.Audit.Queries.GetAuditType
{
    public record GetAuditTypeResponseDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}

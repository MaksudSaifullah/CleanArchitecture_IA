using Internal.Audit.Domain.Entities.config;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internal.Audit.Application.Features.Documents.Queries.GetByDocumentId
{
    public class GetByDocumentIdResponseDTO
    {    
        public Guid Id { get; set; }
        public Guid DocumentSourceId { get; set; }
        public string Path { get; set; } = null!;
        public string Name { get; set; } = null!;
        public string Format { get; set; } = null!;    
        public virtual DocumentSource DocumentSource { get; set; } = null!;
    }
}

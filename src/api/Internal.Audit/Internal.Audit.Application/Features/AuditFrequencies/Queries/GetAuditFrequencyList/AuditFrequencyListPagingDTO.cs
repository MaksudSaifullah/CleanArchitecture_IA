using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internal.Audit.Application.Features.AuditFrequencies.Queries.GetAuditFrequencyList;


    public record AuditFrequencyListPagingDTO
{
    public IEnumerable<AuditFrequencyDTO> Items { get; set; } = null!;
    public long TotalCount { get; set; }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internal.Audit.Application.Features.RiskProfiles.Queries.GetRiskProfileList
{
    public record RiskProfileListPagingDTO
    {
        public IEnumerable<RiskProfileDTO> Items { get; set; } = null!;
        public long TotalCount { get; set; }
    }
}

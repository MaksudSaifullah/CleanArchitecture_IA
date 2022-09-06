using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internal.Audit.Application.Features.RiskCriteriasPCA.Queries.GetRiskCriteriaList
{
    public record RiskCriteriaPCAListPagingDTO
    {
        public IEnumerable<RiskCriteriaPCADTO> Items { get; set; } = null!;
        public long TotalCount { get; set; }
    }
}
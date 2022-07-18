using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internal.Audit.Application.Features.RiskCriterias.Queries.GetRiskCriteriaList
{
    public record RiskCriteriaListPagingDTO
    {
        public IEnumerable<RiskCriteriaDTO> Items { get; set; } = null!;
        public long TotalCount { get; set; }
    }
}
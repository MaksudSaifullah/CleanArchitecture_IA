using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internal.Audit.Application.Features.RiskAssessments.Queries.GetRiskAssessmentList
{
    public record RiskAssessmentListPagingDTO
    {
        public IEnumerable<RiskAssessmentDTO>? Items { get; set; }
        public long TotalCount { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internal.Audit.Application.Features.RiskAssessments.Queries.GetRiskAssessmentList
{
    public record RiskAssessmentDTO
    {
        public Guid Id { get; set; }
        public string? CountryName { get; set; }
        public string? AuditTypeName { get; set; }
        public string AssesmentCode { get; set; } = null!;
        public DateTime EffectiveFrom { get; set; }
        public DateTime EffectiveTo { get; set; }
    }
}

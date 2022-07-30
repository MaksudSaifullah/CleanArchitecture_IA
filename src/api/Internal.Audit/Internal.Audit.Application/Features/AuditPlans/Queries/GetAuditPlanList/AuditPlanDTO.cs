using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internal.Audit.Application.Features.AuditPlans.Queries.GetAuditPlanList
{
    public record AuditPlanDTO
    {
        public Guid Id { get; set; }
        public string? CountryName { get; set; }
        public string? AuditTypeName { get; set; }
        public string? RiskAssessmentCode { get; set; }
        public Guid RiskAssessmentId { get; set; }
        public string? PlanCode { get; set; }
        public Guid PlanningYearId { get; set; }
        public DateTime AssessmentFrom { get; set; }
        public DateTime AssessmentTo { get; set; }
    }
}

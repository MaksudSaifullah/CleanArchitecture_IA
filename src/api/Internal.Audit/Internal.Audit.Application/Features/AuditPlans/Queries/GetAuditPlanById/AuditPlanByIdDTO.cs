using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internal.Audit.Application.Features.AuditPlans.Queries.GetAuditPlanById
{
    public record AuditPlanByIdDTO
    {
        public Guid Id { get; set; }
        public Guid CountryId { get; set; }
        public Guid AuditTypeId { get; set; }
        public string? AssessmentCode { get; set; }
        public Guid RiskAssessmentId { get; set; }
        public string? PlanCode { get; set; }
        public Guid PlanningYearId { get; set; }
        public DateTime AssessmentFrom { get; set; }
        public DateTime AssessmentTo { get; set; }
    }
}

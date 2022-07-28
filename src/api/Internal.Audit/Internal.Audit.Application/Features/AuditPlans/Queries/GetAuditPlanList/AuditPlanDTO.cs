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
        public Guid CountryId { get; set; }
        public string? CountryName { get; set; }
        public Guid AuditTypeId { get; set; }
        public string? AuditTypeName { get; set; }
        public Guid RiskAssesmentId { get; set; }
        public string? AssesmentCode { get; set; }
        public string? PlanningYear { get; set; }
        public DateTime AssesmentFrom { get; set; }
        public DateTime AssesmentTo { get; set; }
    }
}

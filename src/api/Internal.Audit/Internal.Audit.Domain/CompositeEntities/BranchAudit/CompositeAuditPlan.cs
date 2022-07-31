using Internal.Audit.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internal.Audit.Domain.CompositeEntities.BranchAudit
{
    public class CompositeAuditPlan : EntityBase
    {
        public string? CountryName { get; set; }
        public Guid CountryId { get; set; }
        public string? AuditTypeName { get; set; }
        public Guid AuditTypeId { get; set; }
        public string? AssessmentCode { get; set; }
        public string? YearName { get; set; }
        public Guid RiskAssessmentId { get; set; }
        public string? PlanCode { get; set; }
        public Guid PlanningYearId { get; set; }
        public DateTime AssessmentFrom { get; set; }
        public DateTime AssessmentTo { get; set; }
    }
}

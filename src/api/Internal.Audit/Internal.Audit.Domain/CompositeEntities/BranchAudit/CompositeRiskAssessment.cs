using Internal.Audit.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internal.Audit.Domain.CompositeEntities.BranchAudit
{
    public class CompositeRiskAssessment : EntityBase
    {
        public Guid CountryId { get; set; }
        public string? CountryName { get; set; }
        public Guid AuditTypeId { get; set; }
        public string? AuditTypeName { get; set; }
        public string AssesmentCode { get; set; } = null!;
        public DateTime EffectiveFrom { get; set; }
        public DateTime EffectiveTo { get; set; }
    }
}

using Internal.Audit.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internal.Audit.Domain.CompositeEntities.BranchAudit
{
    public class AuditPlanCode: EntityBase
    {
        public string PlanCode { get; set; }
    }
}

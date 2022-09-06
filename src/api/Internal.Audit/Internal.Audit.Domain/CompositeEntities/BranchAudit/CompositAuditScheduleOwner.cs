using Internal.Audit.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internal.Audit.Domain.CompositeEntities.BranchAudit
{
    public class CompositAuditScheduleOwner: EntityBase
    {
       
        public Guid AuditScheduleId { get; set; }
        public string BranchName { get; set; }
        public string UserName { get; set; }
        
    }
}

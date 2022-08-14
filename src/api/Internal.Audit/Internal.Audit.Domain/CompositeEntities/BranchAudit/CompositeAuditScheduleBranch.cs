using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Internal.Audit.Domain.Common;

namespace Internal.Audit.Domain.CompositeEntities.BranchAudit
{
    public class CompositeAuditScheduleBranch : EntityBase
    {
        public Guid Id { get; set; }
        public Guid AuditScheduleId { get; set; }
        public long BranchId { get; set; }
        public int BranchCode { get; set; }
        public string? BranchName { get; set; }
    }
}

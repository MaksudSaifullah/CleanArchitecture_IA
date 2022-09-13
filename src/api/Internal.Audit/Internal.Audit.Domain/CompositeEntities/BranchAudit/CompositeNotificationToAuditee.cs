using Internal.Audit.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internal.Audit.Domain.CompositeEntities.BranchAudit;
public class CompositeNotificationToAuditee : EntityBase
{
    public Guid AuditCreationId { get; set; }
    
}

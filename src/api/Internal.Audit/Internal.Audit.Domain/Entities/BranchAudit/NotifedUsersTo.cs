using Internal.Audit.Domain.Common;
using Internal.Audit.Domain.Entities.Security;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internal.Audit.Domain.Entities.BranchAudit;


[Table("NotifedUsersTo", Schema = "BranchAudit")]
public class NotifedUsersTo : EntityBase
{
    public Guid UserId { get; set; }
    public Guid NotificationToAuditeeId { get; set; }

    [ForeignKey("UserId")]
    public virtual User User { get; set; } = null!;

    [ForeignKey("NotificationToAuditeeId")]
    public virtual NotificationToAuditee NotificationToAuditee { get; set; } = null!;
}

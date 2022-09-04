using Internal.Audit.Domain.Common;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Internal.Audit.Domain.Entities.BranchAudit;
[Table("NotificationToAuditee", Schema = "BranchAudit")]
public class NotificationToAuditee : EntityBase
{

    [Required]
    public Guid AuditCreationId { get; set; }

    [Required]
    [DefaultValue("0")]
    public bool IsSent { get; set; }


    [ForeignKey("AuditCreationId")]
    public virtual AuditCreation AuditCreation { get; set; } = null!;

    //public virtual ICollection<AuditScheduleParticipants> RiskOwnerTo { get; set; } = null!;

    public virtual ICollection<NotifedUsersTo> OthersTo { get; set; } = null!;

    public virtual ICollection<NotifedUsersCC> CC { get; set; } = null!;

    public virtual ICollection<NotifedUsersBCC> BCC { get; set; } = null!;


}
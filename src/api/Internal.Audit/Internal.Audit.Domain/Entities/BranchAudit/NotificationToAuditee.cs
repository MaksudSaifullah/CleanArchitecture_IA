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

    //public virtual ICollection<UserCountry> RiskOwnerTo { get; set; } = null!;
    //public virtual ICollection<OthersTo> OthersTo { get; set; } = null!;

    public virtual ICollection<AuditScheduleParticipants> AuditScheduleParticipants { get; set; } = null!;
    public virtual ICollection<AuditScheduleBranch> AuditScheduleBranch { get; set; } = null!;

}
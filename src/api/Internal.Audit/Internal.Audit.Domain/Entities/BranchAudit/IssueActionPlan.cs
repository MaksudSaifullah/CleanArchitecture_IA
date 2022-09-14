using Internal.Audit.Domain.Common;
using Internal.Audit.Domain.Entities.Security;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Internal.Audit.Domain.Entities.BranchAudit;

[Table("IssueActionPlan", Schema = "BranchAudit")]
public class IssueActionPlan : EntityBase
{
	[Required]
	public string ActionPlanCode { get; set; } = null!;
	[Required]
	public Guid IssueId { get; set; }
	public Guid? EvidenceDocumentId { get; set; }
	[Required]
	[MaxLength(500)]
	public string ManagementPlan { get; set; } = null!;
	[Required]
	public DateTime TargetDate { get; set; }
	[Required]
	[DefaultValue("0")]
	public bool IsActionTaken { get; set; }
	public DateTime? ActionTakenDate { get; set; }
	[MaxLength(500)]
	public string? ActionTakenRemarks { get; set; }
    [NotMapped]
    public string? IssueActionPlanOwners { get; set; }

    [ForeignKey("IssueId")]
	public virtual Issue Issue { get; set; } = null!;
    public virtual ICollection<IssueActionPlanOwner> issueActionPlanOwnerList { get; set; } = null!;
    //TODO
    //[ForeignKey("EvidenceDocumentId")]
    //public virtual Document Document { get; set; } = null!;


}
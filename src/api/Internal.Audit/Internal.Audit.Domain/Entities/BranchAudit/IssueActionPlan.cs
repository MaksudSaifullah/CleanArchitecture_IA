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
	[MaxLength(20)]
	//[Index("Ix_[PlanCode", Order = 1, IsUnique = true)]
	public string ActionPlanCode { get; set; } = null!;
	[Required]
	public Guid IssueId { get; set; }
	[Required]
	public Guid OwnerId { get; set; }
	[Required]
	public Guid EvidenceDocumentId { get; set; }
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


	[ForeignKey("IssueId")]
	public virtual Issue Issue { get; set; } = null!;
	[ForeignKey("OwnerId")]
	public virtual Employee Employee { get; set; } = null!;
	//TODO
	//[ForeignKey("EvidenceDocumentId")]
	//public virtual Document Document { get; set; } = null!;


}
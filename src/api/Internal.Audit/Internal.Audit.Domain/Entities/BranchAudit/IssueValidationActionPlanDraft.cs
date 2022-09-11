using Internal.Audit.Domain.Common;
using Internal.Audit.Domain.Entities.Config;
using Internal.Audit.Domain.Entities.Security;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Internal.Audit.Domain.Entities.BranchAudit;

[Table("IssueValidationActionPlan", Schema = "BranchAudit")]
public class IssueValidationActionPlanDraft : EntityBase
{
	[Required]
	[MaxLength(20)]	
	//todo unique key
	public string Code { get; set; } = null!;
	[Required]
	public Guid ActionOwnerId { get; set; }
	[Required]
	public Guid OETestControlActivityNatureId { get; set; }
	[Required]
	public Guid OETestControlFrequencyId { get; set; }
	[Required]
	public Guid ActionValidatedBy { get; set; }
	[Required]
	public Guid ActionReviewedBy { get; set; }
	[Required]
	public Guid ActionApprovedBy { get; set; }
	[Required]
	[MaxLength(50)]
	public string Name { get; set; } = null!;
	[Required]
	[MaxLength(100)]
	public string Details { get; set; } = null!;
	[Required]
	[MaxLength(200)]
	public string ManagementPlan { get; set; } = null!;
	[Required]
	public DateTime ActionTargetDate { get; set; }
	[Required]
	[MaxLength(300)]
	public string DEATestConclusion { get; set; } = null!;
	[Required]
	[MaxLength(500)]
	public string OETestDetails { get; set; } = null!;
	[Required]
	public int SampleSize { get; set; }
	[Required]
	[MaxLength(300)]
	public string OETestConclusion { get; set; } = null!;
	[Required]
	public DateTime ActionValidationDate { get; set; }
	public DateTime ActionReviewDate { get; set; }
	public DateTime ActionApprovedDate { get; set; }


	[ForeignKey("ActionOwnerId")]
	public virtual Employee ActionOwner { get; set; } = null!;
	[ForeignKey("OETestControlActivityNatureId")]
	public virtual ControlActivityNature ControlActivityNature { get; set; } = null!;

	[ForeignKey("OETestControlFrequencyId")]
	public virtual ControlFrequency ControlFrequency { get; set; } = null!;

	[ForeignKey("ActionValidatedBy")]
	public virtual Employee Validator { get; set; } = null!;
	[ForeignKey("ActionReviewedBy")]
	public virtual Employee Reviewer { get; set; } = null!;
	[ForeignKey("ActionApprovedBy")]
	public virtual Employee Approver { get; set; } = null!;

}
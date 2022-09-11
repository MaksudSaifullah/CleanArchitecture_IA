using Internal.Audit.Domain.Common;
using Internal.Audit.Domain.Entities.common;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Internal.Audit.Domain.Entities.BranchAudit;

[Table("IssueValidationActionPlan", Schema = "BranchAudit")]
public class IssueValidationActionPlan : EntityBase
{
	[Required]
	[MaxLength(20)]
	//todo unique key
	public string Code { get; set; } = null!;
	[Required]
	public string Name { get; set; }
	[Required]
	public string Details { get; set; }
	public string DEATestConclusion { get; set; }
	public string OperatingEffectivenessTestDetails { get; set; }
	public int SampleSize { get; set; }
	public int ControlActivityValue { get; set; }
	public int ControlFrequencyValue { get; set; }
	public string OETestConclusion { get; set; }
	[Required]
	public Guid ActionValidatedBy { get; set; }
	[Required]
	public Guid ActionReviewedBy { get; set; }
	[Required]
	public Guid ActionApprovedBy { get; set; }
	public DateTime ActionValidationDate { get; set; }
	public DateTime ActionReviewDate { get; set; }
	public DateTime ActionApprovedDate { get; set; }
	public Guid? ReviewEvidenceDocumentId { get; set; }
	public Guid? ApprovalEvidenceDocumentId { get; set; }
	public List<IssueValidationTestSheet> IssueValidationTestSheets { get; set; }
	public List<IssueValidationDesignEffectiveNessTestDetail> IssueValidationDesignEffectiveNessTestDetails { get; set; }
	public List<IssueValidationEvidenceDetail> IssueValidationEvidenceDetails { get; set; }
	[NotMapped]
	public virtual Document ReviewEvidenceDocument { get; set; } = null!;
	[NotMapped]
	public virtual Document ApprovalEvidenceDocument { get; set; } = null!;

}

[Table("IssueValidationDesignEffectiveNessTestDetail", Schema = "BranchAudit")]
public class IssueValidationDesignEffectiveNessTestDetail : EntityBase
{
	[Required]
	public Guid IssueValidationActionPlanId { get; set; }
	[Required]
	public int CommonQuestionValue { get; set; }
	public int CommonAnsValue { get; set; }
	public string Remarks { get; set; }
	[ForeignKey("IssueValidationId")]
	public virtual IssueValidationActionPlan IssueValidationActionPlan { get; set; } = null!;

}

[Table("IssueValidationTestSheet", Schema = "BranchAudit")]
public class IssueValidationTestSheet : EntityBase
{
	[Required]
	public Guid IssueValidationActionPlanId { get; set; }
	[Required]
	public Guid DocumentId { get; set; }
	[NotMapped]
	public virtual Document TestingSheet { get; set; } = null!;
	[ForeignKey("IssueValidationId")]
	public virtual IssueValidationActionPlan IssueValidationActionPlan { get; set; } = null!;

}
[Table("IssueValidationEvidenceDetail", Schema = "BranchAudit")]
public class IssueValidationEvidenceDetail : EntityBase
{
	[Required]
	public Guid IssueValidationActionPlanId { get; set; }
	[Required]
	public Guid DocumentId { get; set; }
	[NotMapped]
	public virtual Document TestingSheet { get; set; } = null!;
	[ForeignKey("IssueValidationId")]
	public virtual IssueValidationActionPlan IssueValidationActionPlan { get; set; } = null!;

}

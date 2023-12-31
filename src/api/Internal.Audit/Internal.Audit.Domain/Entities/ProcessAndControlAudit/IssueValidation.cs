﻿using Internal.Audit.Domain.Common;
using Internal.Audit.Domain.Entities.Security;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Internal.Audit.Domain.Entities.ProcessAndControlAudit;

[Table("IssueValidation", Schema = "ProcessAndControlAudit")]
public class IssueValidation : EntityBase
{
	[Required]
	public Guid IssueId { get; set; }
	[Required]
	public Guid ValidatedByUserId { get; set; }	
	public Guid? ReviewedByUserID { get; set; }
	public Guid? ApprovedByUserId { get; set; }
	public Guid? ReviewEvidenceDocumentId { get; set; }
	public Guid? ApprovalEvidenceDocumentId { get; set; }
	[MaxLength(500)]
	public string? ClosureSummary { get; set; }
	[Required]
	public DateTime ValidationDate { get; set; }
	public DateTime? ReviewDate { get; set; }
	public DateTime? ApprovalDate { get; set; }	
	public DateTime? IssueClosureDate { get; set; }	

	[ForeignKey("IssueId")]
	public virtual Issue Issue { get; set; } = null!;
	[ForeignKey("ValidatedByUserId")]
	public virtual Employee Validator { get; set; } = null!;
	[ForeignKey("ReviewedByUserID")]
	public virtual Employee Reviewer { get; set; } = null!;
	[ForeignKey("ApprovedByUserId")]
	public virtual Employee Approvar { get; set; } = null!;

	//TODO
	//[ForeignKey("ReviewEvidenceDocumentId")]
	//public virtual Document ReviewEvidenceDocument { get; set; } = null!;
	//[ForeignKey("ApprovalEvidenceDocumentId")]
	//public virtual Document ApprovalEvidenceDocument { get; set; } = null!;
}
using Internal.Audit.Application.Features.Documents.Queries.GetByDocumentId;
using Internal.Audit.Application.Features.Issues.Queries.GetIssueById;

namespace Internal.Audit.Application.Features.IssueValidations.Queries.GetIssueValidationByIssueId;

public class GetIssueValidationByIssueIdQueryResponseDTO
{	
	public Guid Id { get; set; }
	public Guid IssueId { get; set; }

	public Guid ValidatedByUserId { get; set; }
	public Guid? ReviewedByUserID { get; set; }
	public Guid? ApprovedByUserId { get; set; }
	public Guid? ReviewEvidenceDocumentId { get; set; }
	public Guid? ApprovalEvidenceDocumentId { get; set; }	
	public string? ClosureSummary { get; set; }	
	public DateTime ValidationDate { get; set; }
	public DateTime? ReviewDate { get; set; }
	public DateTime? ApprovalDate { get; set; }
	public DateTime? IssueClosureDate { get; set; }	
	public virtual GetIssueByIdResponseDTO Issue { get; set; } = null!;
	public virtual GetIssueValidationUserListResponseDTO Validator { get; set; } = null!;	
	public virtual GetIssueValidationUserListResponseDTO Reviewer { get; set; } = null!;	
	public virtual GetIssueValidationUserListResponseDTO Approvar { get; set; } = null!;	
	public virtual GetByDocumentIdResponseDTO ReviewEvidenceDocument { get; set; } = null!;
	
	public virtual GetByDocumentIdResponseDTO ApprovalEvidenceDocument { get; set; } = null!;
}
public class GetIssueValidationUserListResponseDTO
{
	public Guid Id { get; set; }

}

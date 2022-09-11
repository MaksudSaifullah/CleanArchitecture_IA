using MediatR;

namespace Internal.Audit.Application.Features.IssueValidations.Commands.UpdateIssueValidationCommand;

public class UpdateIssueValidationCommand:IRequest<UpdateIssueValdiationCommandResponseDTO>
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
}

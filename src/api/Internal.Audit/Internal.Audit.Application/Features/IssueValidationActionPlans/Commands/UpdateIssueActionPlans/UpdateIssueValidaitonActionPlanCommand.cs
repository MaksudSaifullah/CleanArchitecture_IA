using Internal.Audit.Application.Features.IssueValidationActionPlans.Commands.IssueActionPlans;
using MediatR;

namespace Internal.Audit.Application.Features.IssueValidationActionPlans.Commands.UpdateIssueValidationActionPlans;

public class UpdateIssueValidaitonActionPlanCommand:IRequest<UpdateIssueValidationActionPlanResponseDTO>
{
    public Guid Id { get; set; } 
    public string Code { get; set; } = null!;
	public string Name { get; set; }
	public string Details { get; set; }
	public string DEATestConclusion { get; set; }
	public string OperatingEffectivenessTestDetails { get; set; }
	public int SampleSize { get; set; }
	public int ControlActivityValue { get; set; }
	public int ControlFrequencyValue { get; set; }
	public string OETestConclusion { get; set; }	
	public Guid ActionValidatedBy { get; set; }	
	public Guid ActionReviewedBy { get; set; }	
	public Guid ActionApprovedBy { get; set; }
	public DateTime ActionValidationDate { get; set; }
	public DateTime ActionReviewDate { get; set; }
	public DateTime ActionApprovedDate { get; set; }
	public Guid? ReviewEvidenceDocumentId { get; set; }
	public Guid? ApprovalEvidenceDocumentId { get; set; }
	public List<IssueValidationTestSheetDTO> IssueValidationTestSheets { get; set; }
	public List<IssueValidationDesignEffectiveNessTestDetailDTO> IssueValidationDesignEffectiveNessTestDetails { get; set; }
	public List<IssueValidationEvidenceDetailDTO> IssueValidationEvidenceDetails { get; set; }
}

using Internal.Audit.Application.Features.Documents.Queries.GetByDocumentId;
using Internal.Audit.Application.Features.IssueValidations.Queries.GetIssueValidationByIssueId;
using MediatR;

namespace Internal.Audit.Application.Features.IssueValidationActionPlans.Commands.IssueActionPlans;

public class IssueActionPlanCommand:IRequest<IssueActionPlanCommandResponseDTO>
{
	
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
public class IssueValidationDesignEffectiveNessTestDetailDTO
{
	
	//public Guid IssueValidationId { get; set; }

	public int CommonQuestionValue { get; set; }
	public int CommonAnsValue { get; set; }
	public string Remarks { get; set; }	
	//public virtual GetIssueValidationByIssueIdQueryResponseDTO Issue { get; set; } = null!;

}


public class IssueValidationTestSheetDTO
{
	
	//public Guid IssueValidationId { get; set; }
	
	public Guid DocumentId { get; set; }

	//public virtual GetByDocumentIdResponseDTO TestingSheet { get; set; } = null!;

}

public class IssueValidationEvidenceDetailDTO
{ 
	//public Guid IssueValidationId { get; set; }
	
	public Guid DocumentId { get; set; }
	
	//public virtual GetByDocumentIdResponseDTO TestingSheet { get; set; } = null!;

}

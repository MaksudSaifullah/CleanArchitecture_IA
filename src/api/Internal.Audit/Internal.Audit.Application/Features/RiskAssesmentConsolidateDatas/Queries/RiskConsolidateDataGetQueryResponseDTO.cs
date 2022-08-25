namespace Internal.Audit.Application.Features.RiskAssesmentConsolidateDatas.Queries;

public class RiskConsolidateDataGetQueryResponseDTO
{
    public Guid RiskAssesmentId { get; set; }
    public string BranchName { get; set; }
    public int BranchId { get; set; }
    public string Loproductivity_Score { get; set; }
    public string Loproductivity_Rating { get; set; }
    public string Fraud_Score { get; set; }
    public string Fraud_Rating { get; set; }
    public string StaffTurnOver_Score { get; set; }
    public string StaffTurnOver_Rating { get; set; }
    public string OverDue_Score { get; set; }
    public string OverDue_Rating { get; set; }
    public string Collection_Score { get; set; }
    public string Collection_Rating { get; set; }
    public string Disbursement_Score { get; set; }
    public string Disbursement_Rating { get; set; }
}

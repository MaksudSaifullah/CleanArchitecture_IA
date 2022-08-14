using Internal.Audit.Application.Features.CommonValueAndTypes.Queries.GetBranchbyAuditSchedule;

namespace Internal.Audit.Application.Features.RiskAssesmentDataManagementLogs.Queries.GetDataSyncList;

public class GetDataSyncListQueryResponseDTO
{
    public Guid DataRequestQueueServiceId { get; set; }
    public Guid RiskAssesmentId { get; set; }
    public decimal ConversionRate { get; set; }
    public int TypeId { get; set; }
    public virtual ICollection<RiskAssesmentDataManagementDTO> RiskAssesmentDataManagement { get; set; } = null!;
}


public class RiskAssesmentDataManagementDTO
{
    public float Value { get; set; }
    public int Score { get; set; }
    public string Rating { get; set; }
    public bool IsDraft { get; set; }
    public int BranchId { get; set; }
    public Guid RiskAssesmentDataManagementLogId { get; set; }
    public virtual BranchDTO Branch { get; set; }

}
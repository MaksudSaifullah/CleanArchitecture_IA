using Internal.Audit.Domain.Entities.BranchAudit;

namespace Internal.Audit.Application.Contracts.Persistent.RiskAssesmentDataManagementLogs;

public interface IRiskAssesmentDataManagementLogQueryRepository:IAsyncQueryRepository<RiskAssesmentDataManagementLog>
{
    Task<IEnumerable<RiskAssesmentDataManagementLog>> GetDataSyncList(Guid? countryId,Guid? riskassesmentId, DateTime? FromDate, DateTime? ToDate, int typeId, decimal conversionRate, int pageNumber, int pageSize);
}

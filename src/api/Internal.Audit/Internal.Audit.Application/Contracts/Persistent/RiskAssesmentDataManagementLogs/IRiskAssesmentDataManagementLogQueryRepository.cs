using Internal.Audit.Domain.CompositeEntities.BranchAudit;
using Internal.Audit.Domain.Entities.BranchAudit;

namespace Internal.Audit.Application.Contracts.Persistent.RiskAssesmentDataManagementLogs;

public interface IRiskAssesmentDataManagementLogQueryRepository : IAsyncQueryRepository<CompositeRiskAssesmentData>
{
   Task<IEnumerable<CompositeRiskAssesmentData>> GetDataSyncList(Guid? countryId,Guid? riskassesmentId, DateTime? FromDate, DateTime? ToDate, int typeId, decimal conversionRate, int pageNumber, int pageSize);
}

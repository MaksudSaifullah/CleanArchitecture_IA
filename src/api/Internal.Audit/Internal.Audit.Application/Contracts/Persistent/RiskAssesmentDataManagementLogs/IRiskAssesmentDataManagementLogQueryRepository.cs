using Internal.Audit.Domain.Entities.BranchAudit;

namespace Internal.Audit.Application.Contracts.Persistent.RiskAssesmentDataManagementLogs;

public interface IRiskAssesmentDataManagementLogQueryRepository:IAsyncQueryRepository<RiskAssesmentDataManagementLog>
{
}

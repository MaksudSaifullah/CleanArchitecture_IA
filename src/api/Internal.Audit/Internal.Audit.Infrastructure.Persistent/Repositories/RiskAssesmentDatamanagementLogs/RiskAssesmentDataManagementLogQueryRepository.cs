using Internal.Audit.Domain.Entities.BranchAudit;
using Internal.Audit.Application.Contracts.Persistent.RiskAssesmentDataManagementLogs;

namespace Internal.Audit.Infrastructure.Persistent.Repositories.RiskAssesmentDatamanagementLogs;

public class RiskAssesmentDataManagementLogQueryRepository : QueryRepositoryBase<RiskAssesmentDataManagementLog>, IRiskAssesmentDataManagementLogQueryRepository
{
    public RiskAssesmentDataManagementLogQueryRepository(string _connectionString) : base(_connectionString)
    {
    }
}

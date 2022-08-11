using Internal.Audit.Application.Contracts.Persistent.RiskAssesmentDataManagementLogs;
using Internal.Audit.Domain.Entities.BranchAudit;

namespace Internal.Audit.Infrastructure.Persistent.Repositories.RiskAssesmentDatamanagementLogs;

public class RiskAssesmentDataManagementLogCommandRepository : CommandRepositoryBase<RiskAssesmentDataManagementLog>, IRiskAssesmentDataManagementLogCommandRepository
{
    public RiskAssesmentDataManagementLogCommandRepository(InternalAuditContext dbContext) : base(dbContext)
    {
    }
}

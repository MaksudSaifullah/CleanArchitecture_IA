using Internal.Audit.Application.Contracts.Persistent.AuditConfigMilestones;
using Internal.Audit.Domain.Entities.BranchAudit;

namespace Internal.Audit.Infrastructure.Persistent.Repositories.AuditConfigMileStones;

public class AuditConfigMileStoneQueryRepository : QueryRepositoryBase<AuditConfigMileStone>, IAuditConfigMilestoneQueryReposiotry
{
    public AuditConfigMileStoneQueryRepository(string _connectionString) : base(_connectionString)
    {
    }
}

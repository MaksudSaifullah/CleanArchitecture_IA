using Internal.Audit.Application.Contracts.Persistent.AuditConfigMilestones;
using Internal.Audit.Domain.Entities.BranchAudit;

namespace Internal.Audit.Infrastructure.Persistent.Repositories.AuditConfigMileStones;

public class AuditConfigMileStoneCommandRepository : CommandRepositoryBase<AuditConfigMileStone>, IAuditConfigMilestoneCommandReposiotry
{
    public AuditConfigMileStoneCommandRepository(InternalAuditContext dbContext) : base(dbContext)
    {
    }
}

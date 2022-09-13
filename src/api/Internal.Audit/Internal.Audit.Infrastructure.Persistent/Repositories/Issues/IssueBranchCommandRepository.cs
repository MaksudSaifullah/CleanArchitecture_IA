using Internal.Audit.Application.Contracts.Persistent.Issues;
using Internal.Audit.Domain.Entities.BranchAudit;

namespace Internal.Audit.Infrastructure.Persistent.Repositories.Issues;
public class IssueBranchCommandRepository : CommandRepositoryBase<IssueBranch>, IIssueBranchCommandRepository
{
    public IssueBranchCommandRepository(InternalAuditContext context) : base(context)
    {
    }
}

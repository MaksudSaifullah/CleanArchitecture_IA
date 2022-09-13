
using Internal.Audit.Application.Contracts.Persistent.Issues;
using Internal.Audit.Domain.Entities.BranchAudit;

namespace Internal.Audit.Infrastructure.Persistent.Repositories.Issues;
public class IssueCommandRepository : CommandRepositoryBase<Issue>, IIssueCommandRepository
{
    public IssueCommandRepository(InternalAuditContext context) : base(context)
    {
    }
}

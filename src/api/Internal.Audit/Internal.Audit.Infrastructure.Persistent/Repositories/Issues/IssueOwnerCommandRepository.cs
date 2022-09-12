using Internal.Audit.Application.Contracts.Persistent.Issues;
using Internal.Audit.Domain.Entities.Config;

namespace Internal.Audit.Infrastructure.Persistent.Repositories.Issues;
public class IssueOwnerCommandRepository : CommandRepositoryBase<IssueOwner>, IIssueOwnerCommandRepository
{
    public IssueOwnerCommandRepository(InternalAuditContext context) : base(context)
    {
    }
}
using Internal.Audit.Application.Contracts.Persistent.Issues;
using Internal.Audit.Domain.Entities.BranchAudit;

namespace Internal.Audit.Infrastructure.Persistent.Repositories.Issues;
public class IssueActionPlanCommandRepository : CommandRepositoryBase<IssueActionPlan>, IIssueActionPlanCommandRepository
{
    public IssueActionPlanCommandRepository(InternalAuditContext context) : base(context)
    {
    }

}
using Internal.Audit.Application.Contracts.Persistent.IssueValidationActionPlans;
using Internal.Audit.Domain.Entities.BranchAudit;

namespace Internal.Audit.Infrastructure.Persistent.Repositories.IssueValidationActionPlans;

public class IssueValidationActionPlanCommandRepository : CommandRepositoryBase<IssueValidationActionPlan>, IIssueValidationActionPlanCommandRepository
{
    public IssueValidationActionPlanCommandRepository(InternalAuditContext dbContext) : base(dbContext)
    {
    }
}

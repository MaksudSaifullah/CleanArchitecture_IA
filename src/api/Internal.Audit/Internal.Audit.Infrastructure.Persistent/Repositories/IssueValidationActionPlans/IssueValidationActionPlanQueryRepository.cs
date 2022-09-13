using Internal.Audit.Application.Contracts.Persistent.IssueValidationActionPlans;
using Internal.Audit.Domain.Entities.BranchAudit;

namespace Internal.Audit.Infrastructure.Persistent.Repositories.IssueValidationActionPlans;

public class IssueValidationActionPlanQueryRepository : QueryRepositoryBase<IssueValidationActionPlan>, IIssueValidationActionPlanQueryRepository
{
    public IssueValidationActionPlanQueryRepository(string _connectionString) : base(_connectionString)
    {
    }
}

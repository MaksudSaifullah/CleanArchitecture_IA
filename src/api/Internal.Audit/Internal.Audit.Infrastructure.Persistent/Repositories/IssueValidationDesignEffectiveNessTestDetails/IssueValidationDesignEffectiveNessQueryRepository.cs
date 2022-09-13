using Internal.Audit.Application.Contracts.Persistent.IssueValidationDesignEffectiveNessTestDetails;
using Internal.Audit.Domain.Entities.BranchAudit;

namespace Internal.Audit.Infrastructure.Persistent.Repositories.IssueValidationDesignEffectiveNessTestDetails;

public class IssueValidationDesignEffectiveNessQueryRepository : QueryRepositoryBase<IssueValidationDesignEffectiveNessTestDetail>, IIssueValidationDesignEffectiveNessQueryRepository
{
    public IssueValidationDesignEffectiveNessQueryRepository(string _connectionString) : base(_connectionString)
    {
    }
}

using Internal.Audit.Application.Contracts.Persistent.IssueValidations;
using Internal.Audit.Domain.Entities.BranchAudit;

namespace Internal.Audit.Infrastructure.Persistent.Repositories.IssueValidations;

public class IssueValidationCommandReposiotry : CommandRepositoryBase<IssueValidation>, IssueValidationCommandRepository
{
    public IssueValidationCommandReposiotry(InternalAuditContext dbContext) : base(dbContext)
    {
    }
}

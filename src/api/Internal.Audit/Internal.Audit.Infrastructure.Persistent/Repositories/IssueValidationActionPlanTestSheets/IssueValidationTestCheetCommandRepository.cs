using Internal.Audit.Application.Contracts.Persistent.IssueValidationActionPlanTestSheets;
using Internal.Audit.Domain.Entities.BranchAudit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internal.Audit.Infrastructure.Persistent.Repositories.IssueValidationActionPlanTestSheets;

public class IssueValidationTestCheetCommandRepository : CommandRepositoryBase<IssueValidationTestSheet>, IIssueValidationTestCheetCommandRepository
{
    public IssueValidationTestCheetCommandRepository(InternalAuditContext dbContext) : base(dbContext)
    {
    }
}

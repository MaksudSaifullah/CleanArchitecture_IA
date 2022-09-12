using Internal.Audit.Application.Contracts.Persistent.IssueValidationActionPlanTestSheets;
using Internal.Audit.Domain.Entities.BranchAudit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internal.Audit.Infrastructure.Persistent.Repositories.IssueValidationActionPlanTestSheets;

public class IssueValidationTestCheetQueryRepository : QueryRepositoryBase<IssueValidationTestSheet>, IIssueValidationTestCheetQueryRepository
{
    public IssueValidationTestCheetQueryRepository(string _connectionString) : base(_connectionString)
    {
    }
}

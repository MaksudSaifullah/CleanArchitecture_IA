using Internal.Audit.Application.Contracts.Persistent.IssueValidationEvidenceDetails;
using Internal.Audit.Domain.Entities.BranchAudit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internal.Audit.Infrastructure.Persistent.Repositories.IssueValidationEvidenceDetails;

public class IssueValidationEvidenceDetailQueryRepository : QueryRepositoryBase<IssueValidationEvidenceDetail>, IIssueValidationEvidenceDetailQueryRepository
{
    public IssueValidationEvidenceDetailQueryRepository(string _connectionString) : base(_connectionString)
    {
    }
}

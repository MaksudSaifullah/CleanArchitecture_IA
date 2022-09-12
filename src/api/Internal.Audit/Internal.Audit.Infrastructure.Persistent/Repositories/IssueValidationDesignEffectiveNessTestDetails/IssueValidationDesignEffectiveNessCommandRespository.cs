using Internal.Audit.Application.Contracts.Persistent.IssueValidationDesignEffectiveNessTestDetails;
using Internal.Audit.Domain.Entities.BranchAudit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internal.Audit.Infrastructure.Persistent.Repositories.IssueValidationDesignEffectiveNessTestDetails;

public class IssueValidationDesignEffectiveNessCommandRespository : CommandRepositoryBase<IssueValidationDesignEffectiveNessTestDetail>, IIssueValidationDesignEffectiveNessCommandRespository
{
    public IssueValidationDesignEffectiveNessCommandRespository(InternalAuditContext dbContext) : base(dbContext)
    {
    }
}

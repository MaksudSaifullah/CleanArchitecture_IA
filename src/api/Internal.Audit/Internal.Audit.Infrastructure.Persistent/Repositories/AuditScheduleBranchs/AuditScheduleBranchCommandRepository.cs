using Internal.Audit.Application.Contracts.Persistent.AuditScheduleBranches;
using Internal.Audit.Domain.Entities.BranchAudit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internal.Audit.Infrastructure.Persistent.Repositories.AuditScheduleBranchs;

public class AuditScheduleBranchCommandRepository : CommandRepositoryBase<AuditScheduleBranch>, IAuditScheduleBranchCommandRepository
{
    public AuditScheduleBranchCommandRepository(InternalAuditContext dbContext) : base(dbContext)
    {
    }
}

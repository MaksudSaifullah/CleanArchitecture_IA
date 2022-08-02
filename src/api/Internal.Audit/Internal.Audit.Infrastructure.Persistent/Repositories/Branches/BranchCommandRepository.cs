using Internal.Audit.Application.Contracts.Persistent.Branches;
using Internal.Audit.Domain.Entities.security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internal.Audit.Infrastructure.Persistent.Repositories.Branches;

public class BranchCommandRepository : CommandRepositoryBase<Branch>, IBranchCommandRepository
{
    public BranchCommandRepository(InternalAuditContext dbContext) : base(dbContext)
    {
    }
}

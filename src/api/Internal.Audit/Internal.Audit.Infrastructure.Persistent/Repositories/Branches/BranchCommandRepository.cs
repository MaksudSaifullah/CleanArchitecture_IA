using Internal.Audit.Application.Contracts.Persistent.Branches;
using Internal.Audit.Domain.Entities.security;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Internal.Audit.Infrastructure.Persistent.Repositories.Branches;

public class BranchCommandRepository : CommandRepositoryBase<Branch>, IBranchCommandRepository
{
    public BranchCommandRepository(InternalAuditContext dbContext) : base(dbContext)
    {
    }

    public async Task<IReadOnlyList<Branch>> GetWithInclude(Expression<Func<Branch, bool>> predicate)
    {
       return await  _dbContext.Branches.Where(predicate).Include(x => x.Country).ToListAsync();

    }
}

using Internal.Audit.Domain.Entities.security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Internal.Audit.Application.Contracts.Persistent.Branches;

public interface IBranchCommandRepository:IAsyncCommandRepository<Branch>
{
    Task<IReadOnlyList<Branch>> GetWithInclude(Expression<Func<Branch, bool>> predicate);
}

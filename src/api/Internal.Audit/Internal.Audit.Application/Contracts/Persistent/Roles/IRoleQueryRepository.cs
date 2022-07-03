using Internal.Audit.Domain.Entities.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internal.Audit.Application.Contracts.Persistent.Roles;
public interface IRoleQueryRepository : IAsyncQueryRepository<Role>
{
    Task<(long, IEnumerable<Role>)> GetAll(int pageSize, int pageNumber);
    Task<Role> GetById(Guid id);
}


using Internal.Audit.Domain.Entities.common;
using Internal.Audit.Domain.Entities.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internal.Audit.Application.Contracts.Persistent.Roles;
public interface IRoleCommandRepository : IAsyncCommandRepository<Role>
{
    //Task<IReadOnlyList<Role>> Get(bool activeOnly);
}


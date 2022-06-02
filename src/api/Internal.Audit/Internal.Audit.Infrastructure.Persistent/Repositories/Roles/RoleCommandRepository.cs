using Internal.Audit.Domain.Entities.common;
using Internal.Audit.Application.Contracts.Persistent.Roles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internal.Audit.Infrastructure.Persistent.Repositories.Roles;
public class RoleCommandRepository : CommandRepositoryBase<Role>, IRoleCommandRepository
{
    public RoleCommandRepository(InternalAuditContext context) : base(context)
    {
    }
}




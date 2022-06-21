using Internal.Audit.Application.Contracts.Persistent.UserList;
using Internal.Audit.Domain.Entities.security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internal.Audit.Infrastructure.Persistent.Repositories.UserList
{
    public class UpdateUserRoleCommandRepository:CommandRepositoryBase<UserRole>, IUpdateUserRoleCommandRepository
    {
        public UpdateUserRoleCommandRepository(InternalAuditContext context) : base(context)
        {

        }
    }
}

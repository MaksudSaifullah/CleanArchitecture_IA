using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Internal.Audit.Domain.Entities.security;
using Internal.Audit.Application.Contracts.Persistent.UserRoleAccessPrivileges;

namespace Internal.Audit.Infrastructure.Persistent.Repositories.UserRoleAccessPrivileges;

    public class UserRoleAccessPrivilegeCommandRepository : CommandRepositoryBase<UserRoleAccessPrivilege>, IUserRoleAccessPrivilegeCommandRepository
    {
        public UserRoleAccessPrivilegeCommandRepository(InternalAuditContext context) : base(context)
        {
        }
    }


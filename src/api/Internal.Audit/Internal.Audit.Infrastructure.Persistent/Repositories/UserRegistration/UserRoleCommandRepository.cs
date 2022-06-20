using Internal.Audit.Application.Contracts.Persistent.UserRegistration;
using Internal.Audit.Domain.Entities.security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internal.Audit.Infrastructure.Persistent.Repositories.UserRegistration
{
    public class UserRoleCommandRepository : CommandRepositoryBase<UserRole>, IUserRoleCommandRepository
    {
        public UserRoleCommandRepository(InternalAuditContext dbContext) : base(dbContext)
        {
        }
    }
}

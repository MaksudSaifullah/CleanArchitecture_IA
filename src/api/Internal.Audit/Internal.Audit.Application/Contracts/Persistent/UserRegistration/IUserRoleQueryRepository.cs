using Internal.Audit.Domain.Entities.security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internal.Audit.Application.Contracts.Persistent.UserRegistration
{
    public interface IUserRoleQueryRepository : IAsyncQueryRepository<UserRole>
    {
        Task<IEnumerable<UserRole>> GetAllUserRoleListByUserId(Guid userId);

    }
}

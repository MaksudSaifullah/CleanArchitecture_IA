using Internal.Audit.Domain.Entities.Common;
using Internal.Audit.Domain.Entities.security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internal.Audit.Application.Contracts.Persistent.UserRoleAccessPrivileges
{
    public interface IUserRoleAccessPrivilegeQueryRepository : IAsyncQueryRepository<UserRoleAccessPrivilege>
    {
        Task<IEnumerable<UserRoleAccessPrivilege>> GetAll();
        Task<IEnumerable<UserRoleAccessPrivilege>> GetByModuleId(Guid ModuleId);
        Task<IEnumerable<UserRoleAccessPrivilege>> GetAllFeatureId(Guid FeatureId);
    }
}

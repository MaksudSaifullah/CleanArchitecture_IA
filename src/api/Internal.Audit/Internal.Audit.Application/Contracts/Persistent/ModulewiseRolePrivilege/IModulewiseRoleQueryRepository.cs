using Internal.Audit.Domain.Entities.security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internal.Audit.Application.Contracts.Persistent.ModulewiseRolePrivilege
{
    public interface IModulewiseRoleQueryRepository:IAsyncQueryRepository<ModulewiseRolePriviliege>
    {
        Task<(long, IEnumerable<ModulewiseRolePriviliege>)> GetAll(int pageSize, int pageNumber);
        Task<(long, IEnumerable<ModulewiseRolePriviliege>)> GetAllByRoleId(int pageSize, int pageNumber,Guid? roleId);
        Task<ModulewiseRolePriviliege> GetByRoleFeatureModuleId(Guid roleId, Guid auditFeatureId, Guid moduleId);
    }
}

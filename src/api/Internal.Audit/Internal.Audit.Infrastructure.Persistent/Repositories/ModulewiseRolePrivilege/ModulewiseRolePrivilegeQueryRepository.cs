using Internal.Audit.Application.Contracts.Persistent.ModulewiseRolePrivilege;
using Internal.Audit.Domain.Entities.security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internal.Audit.Infrastructure.Persistent.Repositories.ModulewiseRolePrivilege
{
    public class ModulewiseRolePrivilegeQueryRepository : QueryRepositoryBase<Domain.Entities.security.ModulewiseRolePriviliege>, IModulewiseRoleQueryRepository
    {
        public ModulewiseRolePrivilegeQueryRepository(string _connectionString) : base(_connectionString)
        {
        }

        public async Task<(long, IEnumerable<ModulewiseRolePriviliege>)> GetAll(int pageSize, int pageNumber)
        {
            var query = "EXEC [dbo].[GetModulewiseRolePriviliegeListProcedure] @pageSize,@pageNumber";
            var parameters = new Dictionary<string, object> { { "@pageSize", pageSize }, { "@pageNumber", pageNumber } };
            return await GetWithPagingInfo(query, parameters, false);
        }

        public async Task<(long, IEnumerable<ModulewiseRolePriviliege>)> GetAllByRoleId(int pageSize, int pageNumber, Guid roleId)
        {
            var query = "EXEC [dbo].[GetModulewiseRolePriviliegeByRoleIdListProcedure] @pageSize,@pageNumber,@roleId";
            var parameters = new Dictionary<string, object> { { "@pageSize", pageSize }, { "@pageNumber", pageNumber }, { "@roleId", roleId } };
            return await GetWithPagingInfo(query, parameters, false);
        }

        public async Task<ModulewiseRolePriviliege> GetByRoleFeatureModuleId(Guid roleId, Guid auditFeatureId, Guid moduleId)
        {
            var query = @"SELECT *
                        FROM [security].[ModulewiseRolePriviliege]
                        where [AuditModuleId]=@auditModuleId
                        and [AuditFeatureId]=@auditFeatureId
                        and [RoleId]=@roleId";
            var parameters = new Dictionary<string, object> { { "@auditModuleId", moduleId }, { "@auditFeatureId", auditFeatureId }, { "@roleId", roleId } };
            return await Single(query, parameters);
        }
    }
}

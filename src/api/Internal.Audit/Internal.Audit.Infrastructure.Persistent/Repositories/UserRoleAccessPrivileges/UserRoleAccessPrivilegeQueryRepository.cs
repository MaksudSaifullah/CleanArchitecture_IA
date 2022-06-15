using Internal.Audit.Application.Contracts.Persistent.UserRoleAccessPrivileges;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Internal.Audit.Domain.Entities.security;
using Internal.Audit.Domain.Entities.Common;

namespace Internal.Audit.Infrastructure.Persistent.Repositories.UserRoleAccessPrivileges
{
    public class UserRoleAccessPrivilegeQueryRepository : QueryRepositoryBase<UserRoleAccessPrivilege>, IUserRoleAccessPrivilegeQueryRepository
    {
        public UserRoleAccessPrivilegeQueryRepository(string _connectionString) : base(_connectionString)
        {

        }

        public async Task<IEnumerable<UserRoleAccessPrivilege>> GetAll()
        {
            var query = @"SELECT [Id],[RoleId],[ModuleId],[FeatureId],[ActionId],[CreatedBy],[CreatedOn] FROM [security].[UserRoleAccessPrivilege] WHERE [IsDeleted] = 0";
            return await Get(query);
        }

        public async Task<IEnumerable<UserRoleAccessPrivilege>> GetByModuleId(Guid moduleId)
        {
            var query = @"SELECT [Id],[RoleId],[ModuleId],[FeatureId],[ActionId],[CreatedBy],[CreatedOn] FROM [security].[UserRoleAccessPrivilege] WHERE [ModuleId] = @moduleId AND[IsDeleted] = 0";
            var parameters = new Dictionary<string, object> { { "moduleId", moduleId } };
            return await Get(query, parameters);
        }

        public async Task<IEnumerable<UserRoleAccessPrivilege>> GetAllFeatureId(Guid featureId)
        {
            var query = @"SELECT [Id],[RoleId],[ModuleId],[FeatureId],[ActionId],[CreatedBy],[CreatedOn] FROM [security].[UserRoleAccessPrivilege] WHERE [FeatureId] = @featureId AND [IsDeleted] = 0";
            var parameters = new Dictionary<string, object> { { "featureId", featureId } };
            return await Get(query, parameters);
        }


    }
}

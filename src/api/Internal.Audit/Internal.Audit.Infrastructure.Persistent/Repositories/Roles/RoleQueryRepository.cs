using Internal.Audit.Application.Contracts.Persistent.Roles;
using Internal.Audit.Domain.Entities.common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Internal.Audit.Infrastructure.Persistent.Repositories.Roles
{
    public class RoleQueryRepository : QueryRepositoryBase<Role>, IRoleQueryRepository
    {
        public RoleQueryRepository(string _connectionString) : base(_connectionString)
        {
        }
        public async Task<IEnumerable<Role>> GetAll()
        {
            var query = @"SELECT [Id],[Name],[Description] FROM [common].[Role] WHERE [IsDeleted] = 0";
            return await Get(query);
        }
        public async Task<Role> GetById(Guid id)
        {
            var query = "SELECT [Id],[Name],[Description] FROM [common].[Role] WHERE Id = @id AND [IsDeleted] = 0";
            var parameters = new Dictionary<string, object> { { "id", id } };

            return await Single(query, parameters);
        }

        //public async Task<Role> GetByCode(string code)
        //{
        //    var query = "SELECT [Id],[Name],[Code],[Remarks],[CreatedOn] FROM [common].[Country] WHERE Code = @code AND [IsDeleted] = 0";
        //    var parameters = new Dictionary<string, object> { { "code", code } };

        //    return await Single(query, parameters);
        //}
    }
}


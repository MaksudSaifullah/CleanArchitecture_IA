﻿using Internal.Audit.Application.Contracts.Persistent.Roles;
using Internal.Audit.Domain.Entities.Security;
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
        public async Task<(long, IEnumerable<Role>)> GetAll(int pageSize, int pageNumber, dynamic searchTerm = null)
        {
            string searchTermConverted = (object)searchTerm == null ? null : Convert.ToString(searchTerm);
            if (!string.IsNullOrWhiteSpace(searchTermConverted))
            {
                searchTermConverted = searchTermConverted.Replace("{", "").Replace("}", "");
            }
            var query = "EXEC [dbo].[GetRoleListProcedure] @pageSize,@pageNumber,@searchTerm";
            var parameters = new Dictionary<string, object> { { "@pageSize", pageSize }, { "@pageNumber", pageNumber }, { "@searchTerm", searchTermConverted } };
            return await GetWithPagingInfo(query, parameters, false);

        }
        public async Task<Role> GetById(Guid id)
        {
            var query = "SELECT [Id],[Name],[Description],[IsActive] FROM [Security].[Role] WHERE Id = @id AND [IsDeleted] = 0";
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


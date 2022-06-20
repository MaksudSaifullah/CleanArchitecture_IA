using Internal.Audit.Application.Contracts.Persistent.UserList;
using Internal.Audit.Domain.CompositeEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internal.Audit.Infrastructure.Persistent.Repositories.UserList
{
    public class UserQueryRepository : QueryRepositoryBase<CompositeUser>, IUserQueryRepository
    {
        public UserQueryRepository(string _connectionString) : base(_connectionString)
        {

        }
        public async Task<CompositeUser> GetById(Guid userId)
        {
            var query = "EXEC [dbo].[GetUserByIdProcedure] @userId";
            var parameters = new Dictionary<string, object> { { "@userId", userId } };
            return await Single(query, parameters);
        }
    }
}

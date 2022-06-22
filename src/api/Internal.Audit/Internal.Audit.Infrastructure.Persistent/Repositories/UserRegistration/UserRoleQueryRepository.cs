using Internal.Audit.Application.Contracts.Persistent.UserRegistration;
using Internal.Audit.Domain.Entities.security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internal.Audit.Infrastructure.Persistent.Repositories.UserRegistration
{
    public class UserRoleQueryRepository : QueryRepositoryBase<UserRole>, IUserRoleQueryRepository
    {
        public UserRoleQueryRepository(string _connectionString) : base(_connectionString)
        {
        }

        public async Task<IEnumerable<UserRole>> GetAllUserRoleListByUserId(Guid userId)
        {
            var query = @"SELECT *
                        FROM [security].[UserRole]
                        where UserId=@userId";
            var parameters = new Dictionary<string, object> { { "userId", userId } };
            return await Get(query, parameters);
        }
    }
}

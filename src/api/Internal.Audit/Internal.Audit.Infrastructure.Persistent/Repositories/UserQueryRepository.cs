using Internal.Audit.Application.Contracts.Persistent;
using Internal.Audit.Domain.Entities;
using Internal.Audit.Domain.Entities.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internal.Audit.Infrastructure.Persistent.Repositories
{
    internal class UserQueryRepository : QueryRepositoryBase<User>, IUserQueryRepository
    {
        public UserQueryRepository(string _connectionString) : base(_connectionString)
        {
        }

        public async Task<User> Get(long id)
        {
            var query = "SELECT * FROM [dbo].[Users] WHERE Id = @id";
            var parameters = new Dictionary<string, object> { { "id", id } };

            return await Single(query, parameters);
        }

        public async Task<IEnumerable<User>> GetAll(bool activeOnly)
        {
            var query = "SELECT * FROM [dbo].[Users] WHERE [Status] = @status";
            var parameters = new Dictionary<string, object> { { "status", activeOnly } };

            return await Get(query, parameters);
        }

        public async Task<User> GetByUserEmail(string email, string password)
        {
            var query = "SELECT * FROM [dbo].[Users] WHERE [Email] = @email AND [Password] = @password";
            var parameters = new Dictionary<string, object> { { "email", email }, { "password", password } };

            return await Single(query, parameters);
        }
    }
}

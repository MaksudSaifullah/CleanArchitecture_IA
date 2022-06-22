using Internal.Audit.Application.Contracts.Persistent.UserRegistration;
using Internal.Audit.Domain.Entities.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internal.Audit.Infrastructure.Persistent.Repositories.UserRegistration
{
    public class UserCountryQueryRepository : QueryRepositoryBase<UserCountry>, IUserCountryQueryRepository
    {
        public UserCountryQueryRepository(string _connectionString) : base(_connectionString)
        {
        }

        public async Task<IEnumerable<UserCountry>> GetAllUserCountryListByUserId(Guid userId)
        {
            var query = @"SELECT *
                        FROM [security].[UserCountry]
                        where UserId=@userId";
            var parameters = new Dictionary<string, object> { { "userId", userId } };
            return await Get(query, parameters);
        }
    }
}

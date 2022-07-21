using Internal.Audit.Application.Contracts.Persistent.UserRegistration;
using Internal.Audit.Domain.Entities.Security;

namespace Internal.Audit.Infrastructure.Persistent.Repositories.UserRegistration
{
    public class UserProfileQueryRepository : QueryRepositoryBase<User>, IUserProfileQueryRepository
    {
        public UserProfileQueryRepository(string _connectionString) : base(_connectionString)
        {
        }

        public async Task<User> GetByEmail(string email)
        {
            return await Single($"SELECT * FROM [security].[User] where Username = '{email}'", false);
        }
    }
}

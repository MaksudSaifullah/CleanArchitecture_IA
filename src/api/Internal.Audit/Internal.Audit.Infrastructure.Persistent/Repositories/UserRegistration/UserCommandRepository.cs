using Internal.Audit.Application.Contracts.Persistent.UserRegistration;
using Internal.Audit.Domain.Entities.Security;

namespace Internal.Audit.Infrastructure.Persistent.Repositories.UserRegistration
{
    public class UserCommandRepository : CommandRepositoryBase<User>, IUserCommandRepository
    {
        public UserCommandRepository(InternalAuditContext dbContext) : base(dbContext)
        {
        }
        public Task<IReadOnlyList<User>> Get(bool activeOnly)
        {
            return Get(u => u.IsEnabled, u => u.OrderByDescending(x => x.CreatedOn));
        }

        public async Task UpdateUserPassword(string password, Guid userId)
        {
            User user = await _dbContext.Users.FindAsync(userId);
            user.Password = password;
            await base._dbContext.SaveChangesAsync();
        }
    }
}

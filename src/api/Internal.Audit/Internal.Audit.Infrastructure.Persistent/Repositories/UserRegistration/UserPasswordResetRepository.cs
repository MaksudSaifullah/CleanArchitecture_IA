using Internal.Audit.Application.Contracts.Persistent.UserRegistration;
using Internal.Audit.Domain.Entities.security;

namespace Internal.Audit.Infrastructure.Persistent.Repositories.UserRegistration
{
    public class UserPasswordResetRepository : QueryRepositoryBase<UserPasswordReset>,IUserPasswordResetRepository
    {
        public UserPasswordResetRepository(string _connectionString) : base(_connectionString)
        {
        }

        public async Task<bool> IsValidPostCode(string postCode)
        {
            var userPasswordReset = await Single($"SELECT * FROM [security].[UserPasswordReset] where PasswordResetPostCode= '{postCode}' and IsCompleted = 0");
            if (userPasswordReset.PasswordResetPostCodeExpiry < DateTime.Now)
                return false;
            return true;
        }

        public async Task<Guid?> IsValidPreCode(string preCode)
        {
            var userPasswordReset = await Single($"SELECT * FROM [security].[UserPasswordReset] where PasswordResetUrlCode  = '{preCode}' and IsCompleted = 0");
            if (userPasswordReset.PasswordResetUrlCodeExpiry < DateTime.Now)
                return userPasswordReset.UserId;
            return null;
        }
    }
}

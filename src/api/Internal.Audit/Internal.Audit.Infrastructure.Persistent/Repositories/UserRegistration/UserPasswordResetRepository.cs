using Internal.Audit.Application.Contracts.Persistent.UserRegistration;
using Internal.Audit.Domain.Entities.security;

namespace Internal.Audit.Infrastructure.Persistent.Repositories.UserRegistration
{
    public class UserPasswordResetRepository : QueryRepositoryBase<UserPasswordReset>,IUserPasswordResetRepository
    {
        public UserPasswordResetRepository(string _connectionString) : base(_connectionString)
        {
        }

        public async Task<bool> IsValidPreCode(string postCode)
        {
            var userPasswordReset = await Single($"SELECT * FROM [security].[UserPasswordReset] where PasswordResetUrlCode= '{postCode}' and IsCompleted = 0");
            if (userPasswordReset?.PasswordResetUrlCodeExpiry < DateTime.Now)
                return false;
            return userPasswordReset != null;
        }

       

        public async Task<Guid?> UserByValidPostCode(string postcode)
        {
            var userPasswordReset = await Single($"SELECT * FROM [security].[UserPasswordReset] where PasswordResetPostCode  = '{postcode}' and IsCompleted = 0");
            if (userPasswordReset.PasswordResetPostCodeExpiry< DateTime.Now.AddMinutes(5))
                return userPasswordReset.UserId;
            return null;
        }
    }
}

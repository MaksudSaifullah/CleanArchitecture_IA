using Internal.Audit.Application.Contracts.Persistent.UserRegistration;
using Internal.Audit.Domain.Entities.security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internal.Audit.Infrastructure.Persistent.Repositories.UserRegistration
{
    public class UserPasswordResetCommandRepository : CommandRepositoryBase<UserPasswordReset> ,IUserPasswordResetCommandRepository
    {
        public UserPasswordResetCommandRepository(InternalAuditContext dbContext) : base(dbContext)
        {
        }

        public async Task UserPasswordResetCreate(Guid userId, string preCode)
        {
            base._dbContext.Add(new UserPasswordReset
            {
                UserId = userId,
                PasswordResetUrlCode = preCode,
                PasswordResetUrlCodeExpiry = DateTime.Now.AddMinutes(5),
            });
            await _dbContext.SaveChangesAsync();
        }

        public async Task UserPasswordResetUpdatePostCode(string preCode,string postCode)
        {
            var userPasswordReset = _dbContext.UserPasswordResets.FirstOrDefault(x => x.PasswordResetUrlCode == preCode);
            userPasswordReset.PasswordResetPostCode = postCode;
            userPasswordReset.PasswordResetPostCodeExpiry = DateTime.Now.AddMinutes(5);
            _dbContext.Update(userPasswordReset);
            await _dbContext.SaveChangesAsync();
        }
    }
}

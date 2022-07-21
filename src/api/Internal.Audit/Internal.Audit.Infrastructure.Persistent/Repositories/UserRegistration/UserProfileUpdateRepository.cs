using Internal.Audit.Application.Contracts.Persistent.UserRegistration;
using Internal.Audit.Domain.Entities.Security;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internal.Audit.Infrastructure.Persistent.Repositories.UserRegistration
{
    public class UserProfileUpdateRepository : CommandRepositoryBase<User>, IUserProfileUpdateRepository
    {
        public UserProfileUpdateRepository(InternalAuditContext dbContext) : base(dbContext)
        {
        }

        public async Task<bool> UpdateUserProfile(string email,string fullname, string profileImage)
        {
            var user = await _dbContext.Users.FirstOrDefaultAsync(x => x.UserName == email);
            if (user == null)
            {
                throw new NullReferenceException("User Not found by email");
            }
            user.FullName = fullname;
            user.ProfileImageUrl = profileImage;
            _dbContext.Update(user);
            await _dbContext.SaveChangesAsync();
            return true;
        }
    }
}

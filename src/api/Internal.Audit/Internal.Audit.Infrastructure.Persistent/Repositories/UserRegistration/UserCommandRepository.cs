using Internal.Audit.Application.Contracts.Persistent.UserRegistration;
using Internal.Audit.Domain.Entities.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}

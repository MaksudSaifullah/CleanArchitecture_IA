using Internal.Audit.Application.Contracts.Persistent.UserRegistration;
using Internal.Audit.Domain.Entities.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internal.Audit.Infrastructure.Persistent.Repositories.UserRegistration
{
    public class UserCountryCommandRepository : CommandRepositoryBase<UserCountry>, IUserCountryCommandRepository
    {
        public UserCountryCommandRepository(InternalAuditContext dbContext) : base(dbContext)
        {
        }
    }
}

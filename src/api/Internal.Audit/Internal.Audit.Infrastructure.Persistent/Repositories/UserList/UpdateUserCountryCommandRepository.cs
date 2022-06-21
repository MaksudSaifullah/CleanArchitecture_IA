using Internal.Audit.Application.Contracts.Persistent.UserList;
using Internal.Audit.Domain.Entities.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internal.Audit.Infrastructure.Persistent.Repositories.UserList
{
    public class UpdateUserCountryCommandRepository:CommandRepositoryBase<UserCountry>, IUpdateUserCountryCommandRepository
    {
        public UpdateUserCountryCommandRepository(InternalAuditContext context) : base(context)
        {

        }
    }
}

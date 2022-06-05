using Internal.Audit.Application.Contracts.Persistent;
using Internal.Audit.Application.Contracts.Persistent.UserCountries;
using Internal.Audit.Domain.Entities.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internal.Audit.Infrastructure.Persistent.Repositories.UserCountries
{
    public class UserCountryQueryRepository : QueryRepositoryBase<UserCountry>, IUserCountryQueryRepository
    {
        public UserCountryQueryRepository(string _connectionString) : base(_connectionString)
        {
        }
    }
}

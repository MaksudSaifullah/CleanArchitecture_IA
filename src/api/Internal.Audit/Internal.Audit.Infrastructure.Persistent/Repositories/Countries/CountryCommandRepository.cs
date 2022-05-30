using Internal.Audit.Application.Contracts.Persistent.Countries;
using Internal.Audit.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internal.Audit.Infrastructure.Persistent.Repositories.Countries;

public class CountryCommandRepository : CommandRepositoryBase<Country>, ICountryCommandRepository
{
    public CountryCommandRepository(InternalAuditContext context) : base(context)
    {
    }

}

using Internal.Audit.Application.Contracts.Persistent.Countries;
using Internal.Audit.Domain.Entities;

namespace Internal.Audit.Infrastructure.Persistent.Repositories.Countries;

public class CountryCommandRepository : CommandRepositoryBase<Country>, ICountryCommandRepository
{
    public CountryCommandRepository(InternalAuditContext context) : base(context)
    {
    }

}

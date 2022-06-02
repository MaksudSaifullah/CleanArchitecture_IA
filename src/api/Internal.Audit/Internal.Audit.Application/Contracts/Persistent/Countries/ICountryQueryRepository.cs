using Internal.Audit.Domain.Entities;

namespace Internal.Audit.Application.Contracts.Persistent.Countries;

public interface ICountryQueryRepository : IAsyncQueryRepository<Country>
{
    Task<IEnumerable<Country>> GetAll();
    Task<Country> GetById(Guid id);    
}

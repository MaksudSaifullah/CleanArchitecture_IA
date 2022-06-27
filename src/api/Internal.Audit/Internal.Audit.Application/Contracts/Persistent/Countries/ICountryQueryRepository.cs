using Internal.Audit.Domain.Entities;

namespace Internal.Audit.Application.Contracts.Persistent.Countries;

public interface ICountryQueryRepository : IAsyncQueryRepository<Country>
{
    Task<(long, IEnumerable<Country>)> GetAll(int pageSize, int pageNumber);
    Task<Country> GetById(Guid id);    
}

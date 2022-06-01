using Internal.Audit.Domain.Entities.common;

namespace Internal.Audit.Application.Contracts.Persistent.Countries;

public interface IDesignationQueryRepository : IAsyncQueryRepository<Designation>
{
    Task<IEnumerable<Designation>> GetAll();
    Task<Designation> GetById(Guid id);
}


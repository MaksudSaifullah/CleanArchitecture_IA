using Internal.Audit.Domain.Entities.common;

namespace Internal.Audit.Application.Contracts.Persistent.Designations;

public interface IDesignationQueryRepository : IAsyncQueryRepository<Designation>
{
    Task<IEnumerable<Designation>> GetAll();
    Task<Designation> GetById(Guid id);
}


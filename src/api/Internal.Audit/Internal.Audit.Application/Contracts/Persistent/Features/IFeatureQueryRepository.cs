using Internal.Audit.Domain.Entities.Common;

namespace Internal.Audit.Application.Contracts.Persistent.Features;

public interface IFeatureQueryRepository : IAsyncQueryRepository<AuditFeature>
{
    Task<IEnumerable<AuditFeature>> GetAll();
    //Task<Module> GetById(Guid id);
}

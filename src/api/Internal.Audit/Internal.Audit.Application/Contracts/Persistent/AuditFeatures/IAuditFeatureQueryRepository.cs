using Internal.Audit.Domain.Entities.Common;

namespace Internal.Audit.Application.Contracts.Persistent.AuditFeatures;

public interface IAuditFeatureQueryRepository : IAsyncQueryRepository<AuditFeature>
{
    Task<IEnumerable<AuditFeature>> GetAll();
    //Task<Module> GetById(Guid id);
}

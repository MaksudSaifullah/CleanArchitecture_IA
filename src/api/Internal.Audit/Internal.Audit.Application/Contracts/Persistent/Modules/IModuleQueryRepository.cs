using Internal.Audit.Domain.Entities.Common;

namespace Internal.Audit.Application.Contracts.Persistent.Modules;

public interface IModuleQueryRepository : IAsyncQueryRepository<AuditModule>
{
    Task<IEnumerable<AuditModule>> GetAll();
    //Task<Module> GetById(Guid id);
}


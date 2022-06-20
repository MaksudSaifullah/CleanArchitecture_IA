using Internal.Audit.Domain.Entities.Common;

namespace Internal.Audit.Application.Contracts.Persistent.AuditModules;

public interface IAuditModuleQueryRepository : IAsyncQueryRepository<AuditModule>
{
    Task<IEnumerable<AuditModule>> GetAll();
    //Task<Module> GetById(Guid id);
}


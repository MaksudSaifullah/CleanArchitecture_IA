using Internal.Audit.Domain.Entities.Common;

namespace Internal.Audit.Application.Contracts.Persistent.AuditActions;

public interface IAuditActionQueryRepository : IAsyncQueryRepository<AuditAction>
{
    Task<IEnumerable<AuditAction>> GetAll();
    //Task<Module> GetById(Guid id);
}
using Internal.Audit.Domain.Entities.Common;

namespace Internal.Audit.Application.Contracts.Persistent.Actions;

public interface IActionQueryRepository : IAsyncQueryRepository<AuditAction>
{
    Task<IEnumerable<AuditAction>> GetAll();
    //Task<Module> GetById(Guid id);
}
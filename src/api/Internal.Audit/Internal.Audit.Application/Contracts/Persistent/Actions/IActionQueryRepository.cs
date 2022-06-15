using Internal.Audit.Domain.Entities.Common;

namespace Internal.Audit.Application.Contracts.Persistent.Actions;

public interface IActionQueryRepository : IAsyncQueryRepository<Domain.Entities.Common.AuditAction>
{
    Task<IEnumerable<Domain.Entities.Common.AuditAction>> GetAll();
    //Task<Module> GetById(Guid id);
}
using Internal.Audit.Domain.Entities.Common;

namespace Internal.Audit.Application.Contracts.Persistent.Actions;

public interface IActionQueryRepository : IAsyncQueryRepository<Domain.Entities.Common.Action>
{
    Task<IEnumerable<Domain.Entities.Common.Action>> GetAll();
    //Task<Module> GetById(Guid id);
}
using Internal.Audit.Domain.Entities.Common;

namespace Internal.Audit.Application.Contracts.Persistent.Modules;

public interface IModuleQueryRepository : IAsyncQueryRepository<Module>
{
    Task<IEnumerable<Module>> GetAll();
    //Task<Module> GetById(Guid id);
}


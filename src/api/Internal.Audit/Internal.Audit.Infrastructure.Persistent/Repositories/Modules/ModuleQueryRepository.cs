using Internal.Audit.Application.Contracts.Persistent.Modules;
using Internal.Audit.Domain.Entities.Common;

namespace Internal.Audit.Infrastructure.Persistent.Repositories.Modules;
public class ModuleQueryRepository : QueryRepositoryBase<Module>, IModuleQueryRepository
{
    public ModuleQueryRepository(string _connectionString) : base(_connectionString)
    {
    }
    public async Task<IEnumerable<Module>> GetAll()
    {
        var query = "SELECT [Id],[Name],[DisplayName],[IsActive] FROM [common].[Module] WHERE [IsDeleted] = 0";
        return await Get(query);
    }

}

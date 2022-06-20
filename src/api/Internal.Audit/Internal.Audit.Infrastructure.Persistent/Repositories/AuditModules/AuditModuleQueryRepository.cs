using Internal.Audit.Application.Contracts.Persistent.AuditModules;
using Internal.Audit.Domain.Entities.Common;

namespace Internal.Audit.Infrastructure.Persistent.Repositories.Modules;
public class AuditModuleQueryRepository : QueryRepositoryBase<AuditModule>, IAuditModuleQueryRepository
{
    public AuditModuleQueryRepository(string _connectionString) : base(_connectionString)
    {
    }
    public async Task<IEnumerable<AuditModule>> GetAll()
    {
        var query = "SELECT [Id],[Name],[DisplayName],[IsActive] FROM [common].[AuditModule] WHERE [IsDeleted] = 0";
        return await Get(query);
    }

}

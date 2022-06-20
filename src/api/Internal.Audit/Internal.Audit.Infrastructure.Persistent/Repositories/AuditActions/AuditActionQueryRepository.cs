using Internal.Audit.Application.Contracts.Persistent.AuditActions;
using Internal.Audit.Domain.Entities.Common;

namespace Internal.Audit.Infrastructure.Persistent.Repositories.Actions;
public class AuditActionQueryRepository : QueryRepositoryBase<Domain.Entities.Common.AuditAction>, IAuditActionQueryRepository
{
    public AuditActionQueryRepository(string _connectionString) : base(_connectionString)
    {
    }
    public async Task<IEnumerable<Domain.Entities.Common.AuditAction>> GetAll()
    {
        var query = "SELECT [Id],[Name],[DisplayName],[IsActive] FROM [common].[AuditAction] WHERE [IsDeleted] = 0";
        return await Get(query);
    }

}
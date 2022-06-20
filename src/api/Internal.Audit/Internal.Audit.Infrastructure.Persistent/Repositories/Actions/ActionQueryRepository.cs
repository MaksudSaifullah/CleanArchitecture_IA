using Internal.Audit.Application.Contracts.Persistent.Actions;
using Internal.Audit.Domain.Entities.Common;

namespace Internal.Audit.Infrastructure.Persistent.Repositories.Actions;
public class ActionQueryRepository : QueryRepositoryBase<Domain.Entities.Common.AuditAction>, IAuditActionQueryRepository
{
    public ActionQueryRepository(string _connectionString) : base(_connectionString)
    {
    }
    public async Task<IEnumerable<Domain.Entities.Common.AuditAction>> GetAll()
    {
        var query = "SELECT [Id],[Name],[DisplayName],[IsActive] FROM [common].[Action] WHERE [IsDeleted] = 0";
        return await Get(query);
    }

}
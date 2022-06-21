using Internal.Audit.Application.Contracts.Persistent.AuditFeatures;
using Internal.Audit.Domain.Entities.Common;

namespace Internal.Audit.Infrastructure.Persistent.Repositories.Features;
public class AuditFeatureQueryRepository : QueryRepositoryBase<AuditFeature>, IAuditFeatureQueryRepository
{
    public AuditFeatureQueryRepository(string _connectionString) : base(_connectionString)
    {
    }
    public async Task<IEnumerable<AuditFeature>> GetAll()
    {
        var query = "SELECT [Id],[Name],[DisplayName],[IsActive] FROM [common].[AuditFeature] WHERE [IsDeleted] = 0";
        return await Get(query);
    }

}

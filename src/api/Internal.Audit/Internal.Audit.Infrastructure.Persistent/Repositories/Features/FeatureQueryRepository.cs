using Internal.Audit.Application.Contracts.Persistent.Features;
using Internal.Audit.Domain.Entities.Common;

namespace Internal.Audit.Infrastructure.Persistent.Repositories.Features;
public class FeatureQueryRepository : QueryRepositoryBase<AuditFeature>, IFeatureQueryRepository
{
    public FeatureQueryRepository(string _connectionString) : base(_connectionString)
    {
    }
    public async Task<IEnumerable<AuditFeature>> GetAll()
    {
        var query = "SELECT [Id],[Name],[DisplayName],[IsActive] FROM [common].[Feature] WHERE [IsDeleted] = 0";
        return await Get(query);
    }

}

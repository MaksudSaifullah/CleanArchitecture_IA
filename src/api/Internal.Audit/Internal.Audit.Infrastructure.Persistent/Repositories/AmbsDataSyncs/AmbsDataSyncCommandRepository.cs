using Internal.Audit.Application.Contracts.Persistent.AmbsDataSync;
using Internal.Audit.Domain.Entities.security;

namespace Internal.Audit.Infrastructure.Persistent.Repositories.AmbsDataSyncs;

public class AmbsDataSyncCommandRepository : CommandRepositoryBase<AmbsDataSync>, IAmbsDataSyncCommandRepository
{
    public AmbsDataSyncCommandRepository(InternalAuditContext dbContext) : base(dbContext)
    {
    }
}

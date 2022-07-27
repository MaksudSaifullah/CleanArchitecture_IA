using Internal.Audit.Application.Contracts.Persistent.DataRequestQueue;

namespace Internal.Audit.Infrastructure.Persistent.Repositories.DataRequestQueueService;

public class DataRequestCommandRepository : CommandRepositoryBase<Domain.Entities.security.DataRequestQueueService>, IDataRequestCommandRepository
{
    public DataRequestCommandRepository(InternalAuditContext dbContext) : base(dbContext)
    {
    }
}

using Internal.Audit.Application.Contracts.Persistent.TopicHeads;
using Internal.Audit.Domain.Entities.BranchAudit;


namespace Internal.Audit.Infrastructure.Persistent.Repositories.TopicHeads;
public class TopicHeadCommandRepository : CommandRepositoryBase<TopicHead>, ITopicHeadCommandRepository
{
    public TopicHeadCommandRepository(InternalAuditContext context) : base(context)
    {
    }
}

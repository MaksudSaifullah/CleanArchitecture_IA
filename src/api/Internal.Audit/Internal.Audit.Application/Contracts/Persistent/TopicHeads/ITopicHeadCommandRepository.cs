using Internal.Audit.Domain.Entities.BranchAudit;


namespace Internal.Audit.Application.Contracts.Persistent.TopicHeads;
public interface ITopicHeadCommandRepository : IAsyncCommandRepository<TopicHead>
{
    
}

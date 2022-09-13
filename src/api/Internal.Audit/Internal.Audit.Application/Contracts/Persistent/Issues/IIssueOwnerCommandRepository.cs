using Internal.Audit.Domain.Entities.Config;

namespace Internal.Audit.Application.Contracts.Persistent.Issues;
public interface IIssueOwnerCommandRepository : IAsyncCommandRepository<IssueOwner>
{
}

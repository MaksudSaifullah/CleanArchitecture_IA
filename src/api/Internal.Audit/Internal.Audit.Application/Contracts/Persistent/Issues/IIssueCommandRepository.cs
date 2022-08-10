using Internal.Audit.Domain.Entities.BranchAudit;


namespace Internal.Audit.Application.Contracts.Persistent.Issues;
public interface IIssueCommandRepository : IAsyncCommandRepository<Issue>
{
}
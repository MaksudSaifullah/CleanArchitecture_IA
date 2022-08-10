using Internal.Audit.Domain.Entities.BranchAudit;


namespace Internal.Audit.Application.Contracts.Persistent.Issues;
public interface IIssueQueryRepository : IAsyncQueryRepository<Issue>
{
    Task<(long, IEnumerable<Issue>)> GetAll(int pageSize, int pageNumber, dynamic searchTerm = null);
    Task<Issue> GetById(Guid id);
}
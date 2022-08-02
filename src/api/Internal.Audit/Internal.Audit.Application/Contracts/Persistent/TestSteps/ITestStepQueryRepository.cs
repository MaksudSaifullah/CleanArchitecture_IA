using Internal.Audit.Application.Contracts.Persistent;
using Internal.Audit.Domain.CompositeEntities.BranchAudit;

namespace Internal.Audit.Application.Contracts.Persistent.TestSteps;
public interface ITestStepQueryRepository : IAsyncQueryRepository<CompositeTestStep>
{
    Task<(long, IEnumerable<CompositeTestStep>)> GetAll(int pageSize, int pageNumber, dynamic searchTerm = null);
    Task<CompositeTestStep> GetById(Guid id);
}
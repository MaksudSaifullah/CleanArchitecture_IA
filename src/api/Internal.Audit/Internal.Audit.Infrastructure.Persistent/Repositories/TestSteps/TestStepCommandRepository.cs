using Internal.Audit.Application.Contracts.Persistent.TestSteps;
using Internal.Audit.Domain.Entities.BranchAudit;


namespace Internal.Audit.Infrastructure.Persistent.Repositories.TestSteps;
public class TestStepCommandRepository : CommandRepositoryBase<TestStep>, ITestStepCommandRepository
{
    public TestStepCommandRepository(InternalAuditContext context) : base(context)
    {
    }
}

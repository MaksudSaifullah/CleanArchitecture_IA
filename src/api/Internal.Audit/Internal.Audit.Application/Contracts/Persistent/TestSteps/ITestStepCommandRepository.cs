using Internal.Audit.Domain.Entities.BranchAudit;


namespace Internal.Audit.Application.Contracts.Persistent.TestSteps;

public interface ITestStepCommandRepository : IAsyncCommandRepository<TestStep>
{
}


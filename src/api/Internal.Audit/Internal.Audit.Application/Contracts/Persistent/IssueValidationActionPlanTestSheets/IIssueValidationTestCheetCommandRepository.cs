using Internal.Audit.Domain.Entities.BranchAudit;

namespace Internal.Audit.Application.Contracts.Persistent.IssueValidationActionPlanTestSheets;

public interface IIssueValidationTestCheetCommandRepository: IAsyncCommandRepository<IssueValidationTestSheet>
{
}

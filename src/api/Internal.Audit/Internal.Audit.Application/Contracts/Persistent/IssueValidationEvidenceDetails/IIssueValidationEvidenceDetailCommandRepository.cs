using Internal.Audit.Domain.Entities.BranchAudit;

namespace Internal.Audit.Application.Contracts.Persistent.IssueValidationEvidenceDetails;

public interface IIssueValidationEvidenceDetailCommandRepository:IAsyncCommandRepository<IssueValidationEvidenceDetail>
{
}

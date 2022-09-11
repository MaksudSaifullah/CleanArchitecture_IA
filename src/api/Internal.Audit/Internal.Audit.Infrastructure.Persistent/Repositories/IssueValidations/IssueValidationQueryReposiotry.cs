using Internal.Audit.Application.Contracts.Persistent.IssueValidations;
using Internal.Audit.Domain.Entities.BranchAudit;
using Internal.Audit.Domain.Entities.common;
using Internal.Audit.Domain.Entities.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internal.Audit.Infrastructure.Persistent.Repositories.IssueValidations;

public class IssueValidationQueryReposiotry : QueryRepositoryBase<IssueValidation>, IssueValidationQueryRepository
{
    public IssueValidationQueryReposiotry(string _connectionString) : base(_connectionString)
    {
    }

    public async Task<IEnumerable<IssueValidation>> GetAllAsync(Guid IssueId)
    {
        var query = @"SELECT *
  FROM [BranchAudit].[IssueValidation] x
   inner join BranchAudit.Issue y
  on x.issueid=y.Id
  inner join security.[User] p
  on p.Id=x.ValidatedByUserId
   inner join security.[User] q
  on q.Id=x.ReviewedByUserID
   inner join security.[User] r
  on r.Id=x.ApprovedByUserId
  inner join common.Document d
  on x.ReviewEvidenceDocumentId=d.Id
  inner join common.Document h
  on x.ApprovalEvidenceDocumentId=h.Id
 where x.issueid=@id";

        string splitters = "Id, Id, Id, Id";
        var parameters = new Dictionary<string, object> { { "id", IssueId } };


        var data = await Get< IssueValidation,Issue,User, User, User, Document, Document, IssueValidation >(query, (issuevalidation, issue, validateuser, revieweduser, approveduser,reviewevidencedocument,apporvalevidencedocument) =>
        {
            IssueValidation u;
            u=issuevalidation;
            u.Issue=issue;
            u.ApprovalEvidenceDocument = apporvalevidencedocument;
            u.ReviewEvidenceDocument = reviewevidencedocument;
            u.Approvar=approveduser;
            u.Reviewer = revieweduser;
            u.Validator = validateuser;
            return u;
        }, parameters, splitters, false);
       
        return data.Distinct();

    }
}

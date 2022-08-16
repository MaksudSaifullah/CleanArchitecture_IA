using Internal.Audit.Application.Contracts.Persistent.AuditScheduleBranches;
using Internal.Audit.Domain.Entities.BranchAudit;
using Internal.Audit.Domain.Entities.security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internal.Audit.Infrastructure.Persistent.Repositories.AuditScheduleBranchs;


public class AuditScheduleBranchQueryRepository : QueryRepositoryBase<AuditScheduleBranch>, IAuditScheduleBranchQueryRepository
{
    public AuditScheduleBranchQueryRepository(string _connectionString) : base(_connectionString)
    {
    }
    public async Task<IEnumerable<AuditScheduleBranch>> GetByScheduleId(Guid id)
    {
        var query = @"SELECT *
  FROM [BranchAudit].[AuditScheduleBranch] asb
  Inner Join security.Branch brnch on asb.BranchId = brnch.Id 
				 WHERE asb.AuditScheduleId  = @id AND asb.IsDeleted = 0 ";
        var parameters = new Dictionary<string, object> { { "id", id } };


        string splitters = "Id";

        var data = await Get<AuditScheduleBranch, Branch, AuditScheduleBranch>(query, (auditschedulebranch, branch) =>
        {
            AuditScheduleBranch doc;
            doc = auditschedulebranch;
            doc.Branch = branch;


            return doc;
        }, parameters, splitters, false);
        return data.Distinct();

        //return await Get(query, parameters);
    }
}

using Internal.Audit.Application.Contracts.Persistent.AuditScheduleBranches;
using Internal.Audit.Application.Contracts.Persistent.AuditSchedules;
using Internal.Audit.Domain.CompositeEntities.BranchAudit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internal.Audit.Infrastructure.Persistent.Repositories.AuditSchedules
{
    public class AuditScheduleBranchListQueryRepository : QueryRepositoryBase<CompositAuditScheduleBranch>, IAuditScheduleBranchListQueryRepository
    {
        public AuditScheduleBranchListQueryRepository(string _connectionString) : base(_connectionString)
        {

        }

        public async Task<(long, IEnumerable<CompositAuditScheduleBranch>)> GetAll(Guid scheduleId, int pageSize, int pageNumber)
        {
            var query = "EXEC [dbo].[GetAuditScheduleBranchListProcedure] @pageSize,@pageNumber,@scheduleId";
            var parameters = new Dictionary<string, object> { { "@pageSize", pageSize }, { "@pageNumber", pageNumber }, { "@scheduleId", scheduleId } };
            return await GetWithPagingInfo(query, parameters, false);
        }
    }
}

using Internal.Audit.Application.Contracts.Persistent.Audit;
using Internal.Audit.Domain.CompositeEntities.BranchAudit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internal.Audit.Infrastructure.Persistent.Repositories.Audit
{
    public class AuditPlanCodeQueryRepository: QueryRepositoryBase<AuditPlanCode>, IAuditPlanCodeQueryRepository
    {
        public AuditPlanCodeQueryRepository(string _connectionString) : base(_connectionString)
        {

        }

        public async Task<(long, IEnumerable<AuditPlanCode>)> GetAll(Guid countryId,Guid auditTypeId, int pageSize, int pageNumber)
        {
            var query = "EXEC [dbo].[GetAuditPlanCodeListProcedure] @pageSize,@pageNumber,@countryId,@auditTypeId";
            var parameters = new Dictionary<string, object> { { "@countryId", countryId }, { "@auditTypeId", auditTypeId }, { "@pageSize", pageSize }, { "@pageNumber", pageNumber } };
            return await GetWithPagingInfo(query, parameters, false);
        }
    }
}

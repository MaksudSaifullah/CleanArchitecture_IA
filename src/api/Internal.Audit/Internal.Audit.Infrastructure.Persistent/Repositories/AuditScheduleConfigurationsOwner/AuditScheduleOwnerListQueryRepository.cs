using Internal.Audit.Application.Contracts.Persistent.AuditScheduleConfigurationsOwner;
using Internal.Audit.Domain.CompositeEntities.BranchAudit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internal.Audit.Infrastructure.Persistent.Repositories.AuditScheduleConfigurationsOwner
{
    public class AuditScheduleOwnerListQueryRepository : QueryRepositoryBase<CompositAuditScheduleOwner>, IAuditScheduleOwnerListQueryRepository
    {
        public AuditScheduleOwnerListQueryRepository(string _connectionString) : base(_connectionString)
        {

        }
        public async Task<(long, IEnumerable<CompositAuditScheduleOwner>)> GetAll(Guid auditScheduleId, int ownerTypeId, int pageSize, int pageNumber)
        {
            var query = "EXEC [dbo].[GetAuditScheduleOwnerListProcedure] @pageSize,@pageNumber,@auditScheduleId,@ownerTypeId";
            var parameters = new Dictionary<string, object> { { "@pageSize", pageSize }, { "@pageNumber", pageNumber }, { "@auditScheduleId", auditScheduleId }, { "@ownerTypeId", ownerTypeId } };
            return await GetWithPagingInfo(query, parameters, false);
        }
    }
}

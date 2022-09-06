using Internal.Audit.Domain.CompositeEntities.BranchAudit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internal.Audit.Application.Contracts.Persistent.AuditScheduleConfigurationsOwner
{
    public interface IAuditScheduleOwnerListQueryRepository : IAsyncQueryRepository<CompositAuditScheduleOwner>
    {
        Task<(long, IEnumerable<CompositAuditScheduleOwner>)> GetAll(Guid auditScheduleId,int ownerTypeId, int pageSize, int pageNumber);
    }
}

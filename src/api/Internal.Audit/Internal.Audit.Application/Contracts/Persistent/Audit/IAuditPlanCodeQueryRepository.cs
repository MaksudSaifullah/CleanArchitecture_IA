using Internal.Audit.Domain.CompositeEntities.BranchAudit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internal.Audit.Application.Contracts.Persistent.Audit
{
    public interface IAuditPlanCodeQueryRepository: IAsyncQueryRepository<AuditPlanCode>
    {
        Task<(long, IEnumerable<AuditPlanCode>)> GetAll(Guid countryId,Guid auditTypeId, int pageSize, int pageNumber);
    }
}

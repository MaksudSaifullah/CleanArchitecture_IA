using Internal.Audit.Domain.CompositeEntities.BranchAudit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internal.Audit.Application.Contracts.Persistent.AuditSchedules
{
    public interface IAuditScheduleBranchListQueryRepository : IAsyncQueryRepository<CompositAuditScheduleBranch>
    {
        Task<(long, IEnumerable<CompositAuditScheduleBranch>)> GetAll(Guid scheduleId,int pageSize, int pageNumber);
    }
}

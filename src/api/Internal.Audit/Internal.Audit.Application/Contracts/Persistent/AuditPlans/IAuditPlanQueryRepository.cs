using Internal.Audit.Domain.CompositeEntities.BranchAudit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internal.Audit.Application.Contracts.Persistent.AuditPlans
{
    public interface IAuditPlanQueryRepository : IAsyncQueryRepository<CompositeAuditPlan>
    {
        Task<(long, IEnumerable<CompositeAuditPlan>)> GetAll(int pageSize, int pageNumber, dynamic search = null!);

        Task<CompositeAuditPlan> GetById(Guid id);
    }
}

using Internal.Audit.Domain.CompositeEntities.BranchAudit;
using Internal.Audit.Domain.Entities.BranchAudit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internal.Audit.Application.Contracts.Persistent.Audit
{
    public interface IAuditQueryRepository : IAsyncQueryRepository<CompositAudit>
    {
        Task<(long, IEnumerable<CompositAudit>)> GetAll(string searchTerm, int pageSize, int pageNumber);
        Task<CompositAudit> GetById(Guid id);
    }
}

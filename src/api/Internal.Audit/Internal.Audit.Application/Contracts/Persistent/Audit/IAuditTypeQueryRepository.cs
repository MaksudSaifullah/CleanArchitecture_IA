using Internal.Audit.Domain.Entities.Config;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internal.Audit.Application.Contracts.Persistent.Audit
{
    public interface IAuditTypeQueryRepository  : IAsyncQueryRepository<AuditType>
    {
        Task<(long, IEnumerable<AuditType>)> GetAll(int pageSize, int pageNumber);
    }
}

using Internal.Audit.Domain.CompositeEntities;
using Internal.Audit.Domain.Entities.config;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internal.Audit.Application.Contracts.Persistent.EmailConfigs
{
    public interface IEmailConfigQueryRepository : IAsyncQueryRepository<CompositEmailConfig>
    {
        Task<(long, IEnumerable<CompositEmailConfig>)> GetAll(string searchTerm, int pageSize, int pageNumber);
    }
}

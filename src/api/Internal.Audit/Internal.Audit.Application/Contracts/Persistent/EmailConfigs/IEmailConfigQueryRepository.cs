using Internal.Audit.Domain.Entities.config;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internal.Audit.Application.Contracts.Persistent.EmailConfigs
{
    public interface IEmailConfigQueryRepository : IAsyncQueryRepository<EmailConfiguration>
    {
        Task<(long, IEnumerable<EmailConfiguration>)> GetAll(int pageSize, int pageNumber);
        Task<EmailConfiguration> GetById(Guid id);
    }
}

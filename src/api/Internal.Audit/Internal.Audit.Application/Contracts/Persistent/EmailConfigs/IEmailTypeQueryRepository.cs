using Internal.Audit.Domain.CompositeEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internal.Audit.Application.Contracts.Persistent.EmailConfigs
{
    public interface IEmailTypeQueryRepository : IAsyncQueryRepository<EmailType>
    {
        Task<(long, IEnumerable<EmailType>)> GetAll(int pageSize, int pageNumber);
    }
}

using Internal.Audit.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internal.Audit.Application.Contracts.Persistent.RiskProfiles;

public interface IRiskProfileQueryRepository : IAsyncQueryRepository<RiskProfile>
{
    Task<(long, IEnumerable<RiskProfile>)> GetAll(int pageSize, int pageNumber);
    Task<RiskProfile> GetById(Guid id);
}
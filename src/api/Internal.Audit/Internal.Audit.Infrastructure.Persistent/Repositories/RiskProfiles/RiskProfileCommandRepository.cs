using Internal.Audit.Application.Contracts.Persistent.RiskProfiles;
using Internal.Audit.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internal.Audit.Infrastructure.Persistent.Repositories.RiskProfiles;

public class RiskProfileCommandRepository : CommandRepositoryBase<RiskProfile>, IRiskProfileCommandRepository
{
    public RiskProfileCommandRepository(InternalAuditContext context) : base(context)
    {
    }

}

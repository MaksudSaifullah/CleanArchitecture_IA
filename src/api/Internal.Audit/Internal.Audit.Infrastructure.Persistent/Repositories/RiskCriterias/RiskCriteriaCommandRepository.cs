using Internal.Audit.Application.Contracts.Persistent.RiskCriterias;
using Internal.Audit.Domain.Entities.BranchAudit;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internal.Audit.Infrastructure.Persistent.Repositories.RiskCriterias;

public class RiskCriteriaCommandRepository : CommandRepositoryBase<RiskCriteria>, IRiskCriteriaCommandRepository
{
    public RiskCriteriaCommandRepository(InternalAuditContext context) : base(context)
    {
    }

}

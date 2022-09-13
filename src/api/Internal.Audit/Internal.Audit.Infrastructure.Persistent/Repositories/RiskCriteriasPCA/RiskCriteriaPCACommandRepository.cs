using Internal.Audit.Application.Contracts.Persistent.RiskCriteriasPCA;
using Internal.Audit.Domain.Entities.ProcessAndControlAudit;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internal.Audit.Infrastructure.Persistent.Repositories.RiskCriterias;

public class RiskCriteriaPCACommandRepository : CommandRepositoryBase<RiskCriteria>, IRiskCriteriaPCACommandRepository
{
    public RiskCriteriaPCACommandRepository(InternalAuditContext context) : base(context)
    {
    }

}

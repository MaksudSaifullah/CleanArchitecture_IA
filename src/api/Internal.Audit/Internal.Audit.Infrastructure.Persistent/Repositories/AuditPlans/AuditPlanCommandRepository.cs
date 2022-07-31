using Internal.Audit.Application.Contracts.Persistent.AuditPlans;
using Internal.Audit.Domain.Entities.BranchAudit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internal.Audit.Infrastructure.Persistent.Repositories.AuditPlans;

public class AuditPlanCommandRepository : CommandRepositoryBase<AuditPlan>, IAuditPlanCommandRepository
{
    public AuditPlanCommandRepository(InternalAuditContext context) : base(context)
    {
    }

}

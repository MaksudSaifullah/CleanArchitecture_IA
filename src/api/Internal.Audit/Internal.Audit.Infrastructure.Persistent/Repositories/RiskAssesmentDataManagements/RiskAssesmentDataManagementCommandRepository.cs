using Internal.Audit.Application.Contracts.Persistent.RiskAssesmentDataManagements;
using Internal.Audit.Domain.Entities.BranchAudit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internal.Audit.Infrastructure.Persistent.Repositories.RiskAssesmentDataManagements;

public class RiskAssesmentDataManagementCommandRepository : CommandRepositoryBase<RiskAssesmentDataManagement>, IRiskAssesmentDataManagementCommandRepository
{
    public RiskAssesmentDataManagementCommandRepository(InternalAuditContext dbContext) : base(dbContext)
    {
    }
}

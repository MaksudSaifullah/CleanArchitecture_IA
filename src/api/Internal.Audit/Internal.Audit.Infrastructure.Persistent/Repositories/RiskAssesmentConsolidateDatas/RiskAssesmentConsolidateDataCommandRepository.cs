using Internal.Audit.Application.Contracts.Persistent.RiskAssesmentConsolidateDatas;
using Internal.Audit.Domain.Entities.BranchAudit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internal.Audit.Infrastructure.Persistent.Repositories.RiskAssesmentConsolidateDatas;

public class RiskAssesmentConsolidateDataCommandRepository : CommandRepositoryBase<RiskAssesmentConsolidateData>, IRiskAssesmentConsolidateDataCommandRepository
{
    public RiskAssesmentConsolidateDataCommandRepository(InternalAuditContext dbContext) : base(dbContext)
    {
    }
}

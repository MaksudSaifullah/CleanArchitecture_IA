using Internal.Audit.Application.Contracts.Persistent.RiskAssesmentDataManagements;
using Internal.Audit.Domain.Entities.BranchAudit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internal.Audit.Infrastructure.Persistent.Repositories.RiskAssesmentDataManagements;

public class RiskAssesmentDataManagementQueryRepository : QueryRepositoryBase<RiskAssesmentDataManagement>, IRiskAssesmentDataManagementQueryRepository
{
    public RiskAssesmentDataManagementQueryRepository(string _connectionString) : base(_connectionString)
    {
    }
}

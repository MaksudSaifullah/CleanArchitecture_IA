using Internal.Audit.Application.Contracts.Persistent.RiskAssessments;
using Internal.Audit.Domain.Entities.BranchAudit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internal.Audit.Infrastructure.Persistent.Repositories.RiskAssessments;

public class RiskAssessmentCommandRepository : CommandRepositoryBase<RiskAssessment>, IRiskAssessmentCommandRepository
{
    public RiskAssessmentCommandRepository(InternalAuditContext context) : base(context)
    {
    }

}

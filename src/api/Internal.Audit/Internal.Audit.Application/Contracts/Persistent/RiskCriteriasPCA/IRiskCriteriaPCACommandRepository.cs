using Internal.Audit.Domain.Entities.ProcessAndControlAudit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internal.Audit.Application.Contracts.Persistent.RiskCriteriasPCA;

public interface IRiskCriteriaPCACommandRepository : IAsyncCommandRepository<RiskCriteria>
{

}

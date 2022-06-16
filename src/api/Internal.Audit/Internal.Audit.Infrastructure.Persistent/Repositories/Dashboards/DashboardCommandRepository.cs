using Internal.Audit.Application.Contracts.Persistent.Dashboards;
using Internal.Audit.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internal.Audit.Infrastructure.Persistent.Repositories.Dashboards;

public class DashboardCommandRepository : CommandRepositoryBase<DashBoardBase>, IDashboardCommandRepository
{
    public DashboardCommandRepository(InternalAuditContext context) : base(context)
    {
    }

}

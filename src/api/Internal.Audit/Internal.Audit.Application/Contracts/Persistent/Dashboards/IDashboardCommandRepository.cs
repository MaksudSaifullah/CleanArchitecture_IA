using Internal.Audit.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internal.Audit.Application.Contracts.Persistent.Dashboards;
public interface IDashboardCommandRepository : IAsyncCommandRepository<DashBoardBase>
{
    
}

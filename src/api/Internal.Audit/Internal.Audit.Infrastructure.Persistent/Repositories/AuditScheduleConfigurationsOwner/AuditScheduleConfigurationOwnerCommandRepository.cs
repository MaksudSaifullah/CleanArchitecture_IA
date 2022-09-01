using Internal.Audit.Application.Contracts.Persistent.AuditScheduleConfigurationsOwner;
using Internal.Audit.Domain.Entities.BranchAudit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internal.Audit.Infrastructure.Persistent.Repositories.AuditScheduleConfigurationsOwner;

public class AuditScheduleConfigurationOwnerCommandRepository : CommandRepositoryBase<AuditScheduleConfigurationOwner>, IAuditScheduleConfigurationOwnerCommandRepository
{
    public AuditScheduleConfigurationOwnerCommandRepository(InternalAuditContext dbContext) : base(dbContext)
    {
    }
}

using Internal.Audit.Domain.Entities.BranchAudit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internal.Audit.Application.Contracts.Persistent.AuditScheduleConfigurationsOwner;

public interface IAuditScheduleConfigurationOwnerQueryRepository:IAsyncQueryRepository<AuditScheduleConfigurationOwner>
{
    Task<AuditScheduleConfigurationOwner> GetAllAsync(Guid? AuditScheduleId,int TypeId);
}

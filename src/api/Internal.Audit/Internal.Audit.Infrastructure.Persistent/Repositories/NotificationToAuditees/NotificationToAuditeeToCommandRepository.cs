using Internal.Audit.Application.Contracts.Persistent.NotificationToAuditees;
using Internal.Audit.Domain.Entities.BranchAudit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internal.Audit.Infrastructure.Persistent.Repositories.NotificationToAuditees;


public class NotificationToAuditeeToCommandRepository : CommandRepositoryBase<NotifedUsersTo>, INotificationToAuditeeToCommandRepository
{
    public NotificationToAuditeeToCommandRepository(InternalAuditContext dbContext) : base(dbContext)
    {
    }
}

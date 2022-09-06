﻿using Internal.Audit.Domain.CompositeEntities.BranchAudit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internal.Audit.Application.Contracts.Persistent.NotificationToAuditees;

public interface INotificationToAuditeeQueryRepository : IAsyncQueryRepository<CompositeNotificationToAuditee>
{
    Task<(long, IEnumerable<CompositeNotificationToAuditee>)> GetAll(int pageSize, int pageNumber, dynamic search = null!);

    
}

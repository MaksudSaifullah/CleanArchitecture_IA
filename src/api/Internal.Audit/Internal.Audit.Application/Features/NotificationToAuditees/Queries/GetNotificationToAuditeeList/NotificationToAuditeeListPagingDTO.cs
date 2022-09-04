using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internal.Audit.Application.Features.NotificationToAuditees.Queries.GetNotificationToAuditeeList
{
    public record NotificationToAuditeeListPagingDTO
    {
        public IEnumerable<NotificationToAuditeeDTO>? Items { get; set; }
        public long TotalCount { get; set; }
    }

}
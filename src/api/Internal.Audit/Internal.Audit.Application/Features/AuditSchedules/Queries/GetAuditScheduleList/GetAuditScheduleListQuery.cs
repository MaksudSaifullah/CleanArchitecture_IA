using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internal.Audit.Application.Features.AuditSchedules.Queries.GetAuditScheduleList
{
    public class GetAuditScheduleListQuery: IRequest<GetAuditScheduleListPagingDTO>
    {
        public int pageSize { get; set; }
        public int pageNumber { get; set; }
        public ScheduleSearchTerm searchTerm { get; set; }
    }
    public class ScheduleSearchTerm
    {
        public string scheduleId { get; set; }
    }
}

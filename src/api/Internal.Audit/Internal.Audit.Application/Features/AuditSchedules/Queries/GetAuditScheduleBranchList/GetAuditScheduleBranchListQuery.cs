
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internal.Audit.Application.Features.AuditSchedules.Queries.GetAuditScheduleBranchList
{
    public class GetAuditScheduleBranchListQuery: IRequest<GetAuditScheduleBranchListPagingDTO>
    {
        public int pageSize { get; set; }
        public int pageNumber { get; set; }
        public SearchTerm searchTerm { get; set; }
    }
    public class SearchTerm
    {
        public Guid scheduleId { get; set; }
    }
}

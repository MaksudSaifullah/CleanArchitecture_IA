using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internal.Audit.Application.Features.Audit.Queries.GetAuditList
{
    public class GetAuditListQuery: IRequest<GetAuditListPagingDTO>
    {
        public int pageSize { get; set; }
        public int pageNumber { get; set; }
        public AuditSearchTerm searchTerm { get; set; }
    }

    public class AuditSearchTerm
    {
        public string auditId  { get; set; }
    }
}

using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internal.Audit.Application.Features.Audit.Queries.GetAuditType
{
    public class GetAuditTypeQuery: IRequest<AuditTypePagingDTO>
    {
        public int pageSize { get; set; }
        public int pageNumber { get; set; }
    }
}

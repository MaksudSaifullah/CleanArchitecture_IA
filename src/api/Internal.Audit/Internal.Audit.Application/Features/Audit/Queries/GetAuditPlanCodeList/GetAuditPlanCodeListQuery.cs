using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internal.Audit.Application.Features.Audit.Queries.GetAuditPlanCodeList
{
    public class GetAuditPlanCodeListQuery: IRequest<AuditPlanCodePagingDTO>
    {
        public int pageSize { get; set; }
        public int pageNumber { get; set; }
        public PlanCodeSearchTerm searchTerm { get; set; }
        
    }
    public class PlanCodeSearchTerm
    {
        public Guid countryId { get; set; }
        public Guid auditTypeId { get; set; }
    }
}

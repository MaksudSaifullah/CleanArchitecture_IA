using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internal.Audit.Application.Features.AuditScheduleConfigurationsOwner.Queries.GetOwnerList
{
    public class GetOwnerListQuery:IRequest<GetOwnerListPagingDTO>
    {
        public int pageSize { get; set; }
        public int pageNumber { get; set; }
        public OwnerSearchTerm searchTerm { get; set; }
    }
    public class OwnerSearchTerm
    {
        public Guid auditScheduleId { get; set; }
        public int ownerTypeId { get; set; }
    }
}

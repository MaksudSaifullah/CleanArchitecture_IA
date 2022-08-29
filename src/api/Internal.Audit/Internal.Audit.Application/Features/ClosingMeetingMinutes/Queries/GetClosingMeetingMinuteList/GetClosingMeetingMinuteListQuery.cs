using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internal.Audit.Application.Features.ClosingMeetingMinutes.Queries.GetClosingMeetingMinuteList
{
    public class GetClosingMeetingMinuteListQuery : IRequest<ClosingMeetingMinuteListPagingDTO>
    {
        public int pageSize { get; set; }
        public int pageNumber { get; set; }
        public dynamic searchTerm { get; set; }

    }
}



﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internal.Audit.Application.Features.ClosingMeetingMinutes.Queries.GetClosingMeetingMinuteList
{
    public record ClosingMeetingMinuteListPagingDTO
    {
        public IEnumerable<ClosingMeetingMinuteDTO>? Items { get; set; }
        public long TotalCount { get; set; }
    }

}


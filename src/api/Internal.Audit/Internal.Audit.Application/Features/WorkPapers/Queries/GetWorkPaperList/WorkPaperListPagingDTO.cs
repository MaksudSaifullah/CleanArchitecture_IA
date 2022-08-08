using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internal.Audit.Application.Features.WorkPapers.Queries.GetWorkPaperList;

public record WorkPaperListPagingDTO
{
    public IEnumerable<WorkPaperDTO>? Items { get; set; }
    public long TotalCount { get; set; }
}
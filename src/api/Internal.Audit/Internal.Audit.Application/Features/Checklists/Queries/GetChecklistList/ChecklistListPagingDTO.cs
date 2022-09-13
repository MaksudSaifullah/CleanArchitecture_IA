using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internal.Audit.Application.Features.Checklists.Queries.GetChecklistList;

public record ChecklistListPagingDTO
{
    public IEnumerable<ChecklistDTO>? Items { get; set; }
    public long TotalCount { get; set; }
}

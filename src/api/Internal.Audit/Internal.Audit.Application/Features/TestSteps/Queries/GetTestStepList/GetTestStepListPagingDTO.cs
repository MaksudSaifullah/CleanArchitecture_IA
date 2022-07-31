using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internal.Audit.Application.Features.TestSteps.Queries.GetTestStepList;
public record GetTestStepListPagingDTO
{
    public IEnumerable<GetTestStepListQueryResponseDTO> Items { get; set; } = null!;
    public long TotalCount { get; set; }
}
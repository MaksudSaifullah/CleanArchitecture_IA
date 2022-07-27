using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internal.Audit.Application.Features.Questionnnaires.Queries.GetQuestionnnaireList;
public record GetQuestionnaireListPagingDTO
{
    public IEnumerable<GetQuestionnaireListResponseDTO> Items { get; set; } = null!;
    public long TotalCount { get; set; }
}

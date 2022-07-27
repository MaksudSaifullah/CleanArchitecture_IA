using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internal.Audit.Application.Features.TopicHeads.Queries.GetTopicHeadList;
public record TopicHeadListPagingDTO
{
    public IEnumerable<TopicHeadDTO> Items { get; set; } = null!;
    public long TotalCount { get; set; }
}
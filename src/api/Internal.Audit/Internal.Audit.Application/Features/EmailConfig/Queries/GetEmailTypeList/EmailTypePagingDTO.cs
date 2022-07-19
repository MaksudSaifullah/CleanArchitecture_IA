using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internal.Audit.Application.Features.EmailConfig.Queries.GetEmailTypeList
{
    public record EmailTypePagingDTO
    {
        public IEnumerable<GetEmailTypeListResponseDTO> Items { get; set; } = null!;
        public long TotalCount { get; set; }
    }
}

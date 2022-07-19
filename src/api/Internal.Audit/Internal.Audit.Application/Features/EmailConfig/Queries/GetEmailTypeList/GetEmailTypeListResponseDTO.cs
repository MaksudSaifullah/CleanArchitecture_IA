using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internal.Audit.Application.Features.EmailConfig.Queries.GetEmailTypeList
{
    public record GetEmailTypeListResponseDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}

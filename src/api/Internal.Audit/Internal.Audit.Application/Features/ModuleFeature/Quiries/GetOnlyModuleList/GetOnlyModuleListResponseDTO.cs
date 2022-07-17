using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internal.Audit.Application.Features.ModuleFeature.Quiries.GetOnlyModuleList
{
    public class GetOnlyModuleListResponseDTO
    {
        public Guid Id { get; set; }
        public string DisplayName { get; set; }
    }
}

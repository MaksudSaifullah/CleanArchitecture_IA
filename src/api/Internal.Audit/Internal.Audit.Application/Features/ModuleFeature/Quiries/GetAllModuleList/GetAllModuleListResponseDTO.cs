using Internal.Audit.Domain.CompositeEntities;
using Internal.Audit.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internal.Audit.Application.Features.ModuleFeature.Quiries.GetAllModuleList
{
    public class GetAllModuleListResponseDTO
    {
        public Guid Id { get; set; }
        public Guid ModuleId { get; set; }        
        public Guid FeatureId { get; set; }      
        public virtual AuditModule Module { get; set; } = null!;       
        public virtual Domain.Entities.Common.AuditFeature Feature { get; set; } = null!;
        public virtual EfTotalCount TotalCount { get; set; } = null!;
    }
}

using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internal.Audit.Application.Features.ModulewiseRolePrivilege.Quiries.GetModulewiseRoleListByRoleFeatureModuleId
{
    public class GetModulewiseRoleListByRoleFeatureModuleIdQuery:IRequest<GetModulewiseRoleListByRoleFeatureModuleIdQueryResponseDTO>
    {
        public Guid auditFeatureId { get; set; }
        public Guid moduleId { get; set; }
        public Guid roleId { get; set; }
        
    }
}

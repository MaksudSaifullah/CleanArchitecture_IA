using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internal.Audit.Application.Features.ModulewiseRolePrivilege.Commands.UpdateModulewisePrivilege
{
    public class UpdateModulewiseRolePrivilegeCommand:IRequest<UpdateModulewiseRolePrivilegeResponseDTO>
    {
        public Guid Id { get; set; }
        public Guid AuditModuleId { get; set; }
        public Guid AuditFeatureId { get; set; }
        public Guid RoleId { get; set; }
        public bool IsView { get; set; }
        public bool IsCreate { get; set; }
        public bool IsEdit { get; set; }
        public bool IsDelete { get; set; }
    }
}

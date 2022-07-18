using Internal.Audit.Application.Contracts.Persistent.ModulewiseRolePrivilege;
using Internal.Audit.Domain.Entities.security;

namespace Internal.Audit.Infrastructure.Persistent.Repositories.ModulewiseRolePrivilege;

public class ModulewiseRolePrivilegeCommandRepository : CommandRepositoryBase<Domain.Entities.security.ModulewiseRolePriviliege>, IModulewiseRolePrivilegeCommandRepository
{
    public ModulewiseRolePrivilegeCommandRepository(InternalAuditContext context) : base(context)
    {
    }

    public async Task<IReadOnlyList<ModulewiseRolePriviliege>> GetByRoleAuditFeatureId(Guid roleId, Guid featureId, Guid moduleId)
    {
        var modulewiseRolePriviliegeObject = await Get(x => x.RoleId == roleId && x.AuditFeatureId == featureId && x.AuditModuleId == moduleId);
        return modulewiseRolePriviliegeObject;
    }
}

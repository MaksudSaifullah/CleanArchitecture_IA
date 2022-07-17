using Internal.Audit.Application.Contracts.Persistent.ModulewiseRolePrivilege;

namespace Internal.Audit.Infrastructure.Persistent.Repositories.ModulewiseRolePrivilege;

public class ModulewiseRolePrivilegeCommandRepository : CommandRepositoryBase<Domain.Entities.security.ModulewiseRolePriviliege>, IModulewiseRolePrivilegeCommandRepository
{
    public ModulewiseRolePrivilegeCommandRepository(InternalAuditContext context) : base(context)
    {
    }

}

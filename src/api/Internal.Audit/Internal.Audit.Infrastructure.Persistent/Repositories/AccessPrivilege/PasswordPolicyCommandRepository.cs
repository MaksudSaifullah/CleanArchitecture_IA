using Internal.Audit.Application.Contracts.Persistent.AccessPrivilege;
using Internal.Audit.Domain.Entities.security;

namespace Internal.Audit.Infrastructure.Persistent.Repositories.AccessPrivilege;
public class PasswordPolicyCommandRepository : CommandRepositoryBase<PasswordPolicy>, IPasswordPolicyCommandRepository
{
    public PasswordPolicyCommandRepository(InternalAuditContext context) : base(context)
    {
    }
}
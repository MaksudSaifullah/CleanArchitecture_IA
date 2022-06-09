using Internal.Audit.Application.Contracts.Persistent.AccessPrivilege;
using Internal.Audit.Domain.Entities.security;

namespace Internal.Audit.Infrastructure.Persistent.Repositories.AccessPrivilege;
public class UserLockingPolicyCommandRepository : CommandRepositoryBase<UserLockingPolicy>, IUserLockingPolicyCommandRepository
{
    public UserLockingPolicyCommandRepository(InternalAuditContext context) : base(context)
    {
    }
}
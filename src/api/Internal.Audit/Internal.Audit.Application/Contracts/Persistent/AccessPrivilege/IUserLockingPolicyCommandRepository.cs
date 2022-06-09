using Internal.Audit.Domain.Entities.security;

namespace Internal.Audit.Application.Contracts.Persistent.AccessPrivilege;
public interface IUserLockingPolicyCommandRepository : IAsyncCommandRepository<UserLockingPolicy>
{

}

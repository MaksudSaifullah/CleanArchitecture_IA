using Internal.Audit.Domain.Entities.security;

namespace Internal.Audit.Application.Contracts.Persistent.AccessPrivilege;
public interface IUserLockingPolicyQueryRepository : IAsyncQueryRepository<UserLockingPolicy>
{
    public Task<UserLockingPolicy> Get();
}
using Internal.Audit.Domain.Entities.security;
namespace Internal.Audit.Application.Contracts.Persistent.AccessPrivilege;
public interface ISessionPolicyQueryRepository : IAsyncQueryRepository<SessionPolicy>
{
    public Task<SessionPolicy> Get();
}
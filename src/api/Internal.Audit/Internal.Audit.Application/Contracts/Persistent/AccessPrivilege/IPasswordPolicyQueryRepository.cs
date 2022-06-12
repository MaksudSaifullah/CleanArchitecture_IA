using Internal.Audit.Domain.Entities.security;

namespace Internal.Audit.Application.Contracts.Persistent.AccessPrivilege;
public interface IPasswordPolicyQueryRepository : IAsyncQueryRepository<PasswordPolicy>
{
    Task<PasswordPolicy> Get();
}
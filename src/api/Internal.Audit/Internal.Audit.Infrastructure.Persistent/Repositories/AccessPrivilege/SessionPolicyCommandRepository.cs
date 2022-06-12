using Internal.Audit.Application.Contracts.Persistent.AccessPrivilege;
using Internal.Audit.Domain.Entities.security;

namespace Internal.Audit.Infrastructure.Persistent.Repositories.AccessPrivilege;
public class SessionPolicyCommandRepository : CommandRepositoryBase<SessionPolicy>, ISessionPolicyCommandRepository
{
    public SessionPolicyCommandRepository(InternalAuditContext context) : base(context)
    {
    }
}
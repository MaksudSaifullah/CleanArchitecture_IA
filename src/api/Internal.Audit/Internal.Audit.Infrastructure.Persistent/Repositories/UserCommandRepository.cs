
using Internal.Audit.Application.Contracts.Persistent;
using Internal.Audit.Domain.Entities;
using Internal.Audit.Domain.Entities.Security;

namespace Internal.Audit.Infrastructure.Persistent.Repositories;

public class UserCommandRepository : CommandRepositoryBase<User>, IUserCommandRepository
{
    public UserCommandRepository(InternalAuditContext context): base(context)
    {
    }   
    
    public Task<IReadOnlyList<User>> Get(bool activeOnly)
    {
        return Get(u => u.IsEnabled, u => u.OrderByDescending(x => x.CreatedOn));
    }
}

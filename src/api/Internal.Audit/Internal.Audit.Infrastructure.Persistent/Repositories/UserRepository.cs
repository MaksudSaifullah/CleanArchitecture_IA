
using Internal.Audit.Application.Contracts.Persistent;
using Internal.Audit.Domain.Entities;

namespace Internal.Audit.Infrastructure.Persistent.Repositories;

public class UserRepository : RepositoryBase<User>, IUserRepository
{
    public UserRepository(InternalAuditContext context): base(context)
    {
    }   
    
    public Task<IReadOnlyList<User>> Get(bool activeOnly)
    {
        return Get(u => u.Status, u => u.OrderByDescending(x => x.CreatedOn));
    }
}


using Internal.Audit.Application.Contracts.Persistent;
using Internal.Audit.Domain.Entities;

namespace Internal.Audit.Infrastructure.Persistent.Repositories;

public class UserCommandRepository : CommandRepositoryBase<User>, IUserCommandRepository
{
    public UserCommandRepository(InternalAuditContext context): base(context)
    {
    }   
    
    public Task<IReadOnlyList<User>> Get(bool activeOnly)
    {
        return Get(u => u.Status, u => u.OrderByDescending(x => x.CreatedOn));
    }
}

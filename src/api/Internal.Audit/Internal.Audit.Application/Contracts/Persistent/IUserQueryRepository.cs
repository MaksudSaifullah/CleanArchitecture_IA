
using Internal.Audit.Domain.Entities;
using Internal.Audit.Domain.Entities.Security;

namespace Internal.Audit.Application.Contracts.Persistent;

public interface IUserQueryRepository: IAsyncQueryRepository<User>
{
    Task<IEnumerable<User>> GetAll(bool activeOnly);
    Task<User> Get(long id);
    Task<User> GetByUserEmail(string email, string password);
}

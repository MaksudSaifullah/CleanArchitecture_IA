
using Internal.Audit.Domain.Entities;

namespace Internal.Audit.Application.Contracts.Persistent
{
    public interface IUserRepository: IAsyncRepository<User>
    {
        Task<IReadOnlyList<User>> Get(bool activeOnly);
    }
}

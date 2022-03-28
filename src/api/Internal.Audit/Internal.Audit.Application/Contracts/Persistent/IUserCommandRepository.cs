
using Internal.Audit.Domain.Entities;

namespace Internal.Audit.Application.Contracts.Persistent
{
    public interface IUserCommandRepository: IAsyncCommandRepository<User>
    {
        Task<IReadOnlyList<User>> Get(bool activeOnly);
    }
}


using Internal.Audit.Domain.Entities;
using Internal.Audit.Domain.Entities.Security;

namespace Internal.Audit.Application.Contracts.Persistent
{
    public interface IUserCommandRepository: IAsyncCommandRepository<User>
    {
        Task<IReadOnlyList<User>> Get(bool activeOnly);
    }
}

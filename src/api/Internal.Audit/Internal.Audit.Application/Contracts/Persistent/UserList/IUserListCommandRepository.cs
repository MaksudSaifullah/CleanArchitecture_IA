using Internal.Audit.Domain.Entities.Security;

namespace Internal.Audit.Application.Contracts.Persistent.UserList;
public interface IUserListCommandRepository : IAsyncCommandRepository<User>
{
}

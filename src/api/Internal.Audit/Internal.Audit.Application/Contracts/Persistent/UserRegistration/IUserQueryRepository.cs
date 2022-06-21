using Internal.Audit.Domain.Entities.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internal.Audit.Application.Contracts.Persistent.UserRegistration
{
    public interface IUserQueryRepository : IAsyncQueryRepository<User>
    {
        Task<IEnumerable<User>> GetAll(bool activeOnly);
        Task<User> Get(long id);
        Task<User> GetByUserEmail(string email, string password);
        Task<IEnumerable<User>> GetAllUserList(Guid userId);
    }
}

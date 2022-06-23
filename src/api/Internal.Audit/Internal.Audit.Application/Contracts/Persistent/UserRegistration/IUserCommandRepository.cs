using Internal.Audit.Domain.Entities.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internal.Audit.Application.Contracts.Persistent.UserRegistration
{
    public interface IUserCommandRepository:IAsyncCommandRepository<User>
    {
        Task<IReadOnlyList<User>> Get(bool activeOnly);

    }
}

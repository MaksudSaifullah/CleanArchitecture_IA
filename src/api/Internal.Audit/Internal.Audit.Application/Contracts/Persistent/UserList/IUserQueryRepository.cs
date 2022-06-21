using Internal.Audit.Domain.CompositeEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internal.Audit.Application.Contracts.Persistent.UserList
{
    public interface IUserQueryRepository: IAsyncQueryRepository<CompositeUser>
    {
        Task<CompositeUser> GetById(Guid userId);
    }
}

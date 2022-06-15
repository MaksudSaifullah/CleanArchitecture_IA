using Internal.Audit.Domain.CompositeEntities;
using Internal.Audit.Domain.Entities.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internal.Audit.Application.Contracts.Persistent.UserList
{
    public interface IUserListQueryRepository:IAsyncQueryRepository<CompositeUser>
    {
        Task<IEnumerable<CompositeUser>> GetAll(string userName, string employeeName, string userRole);
        Task<CompositeUser> GetById(Guid id);
    }
}

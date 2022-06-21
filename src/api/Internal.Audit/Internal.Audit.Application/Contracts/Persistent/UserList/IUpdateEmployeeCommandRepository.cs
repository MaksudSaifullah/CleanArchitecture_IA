using Internal.Audit.Domain.Entities.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internal.Audit.Application.Contracts.Persistent.UserList
{
    public interface IUpdateEmployeeCommandRepository:IAsyncCommandRepository<Employee>
    {
    }
}

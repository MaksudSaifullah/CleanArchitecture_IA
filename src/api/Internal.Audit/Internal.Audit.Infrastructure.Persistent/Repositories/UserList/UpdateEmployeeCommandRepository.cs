using Internal.Audit.Application.Contracts.Persistent.UserList;
using Internal.Audit.Domain.Entities.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internal.Audit.Infrastructure.Persistent.Repositories.UserList
{
    public class UpdateEmployeeCommandRepository: CommandRepositoryBase<Employee>, IUpdateEmployeeCommandRepository
    {
        public UpdateEmployeeCommandRepository(InternalAuditContext context) : base(context)
        {

        }
    }
}

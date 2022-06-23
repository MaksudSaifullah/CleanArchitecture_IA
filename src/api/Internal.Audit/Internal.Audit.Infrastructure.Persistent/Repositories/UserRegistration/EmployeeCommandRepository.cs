using Internal.Audit.Application.Contracts.Persistent.UserRegistration;
using Internal.Audit.Domain.Entities.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internal.Audit.Infrastructure.Persistent.Repositories.UserRegistration
{
    public class EmployeeCommandRepository : CommandRepositoryBase<Employee>, IEmployeeCommandRepository
    {
        public EmployeeCommandRepository(InternalAuditContext dbContext) : base(dbContext)
        {
        }
    }
}

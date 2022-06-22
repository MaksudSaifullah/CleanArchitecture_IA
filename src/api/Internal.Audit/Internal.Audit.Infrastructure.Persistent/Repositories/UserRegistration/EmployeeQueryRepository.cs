using Internal.Audit.Application.Contracts.Persistent.UserRegistration;
using Internal.Audit.Domain.Entities.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internal.Audit.Infrastructure.Persistent.Repositories.UserRegistration
{
    public class EmployeeQueryRepository : QueryRepositoryBase<Employee>, IEmployeeQueryRepository
    {
        public EmployeeQueryRepository(string _connectionString) : base(_connectionString)
        {
        }

        //public Task<IEnumerable<User>> GetAllUserListByUserId(Guid userId)
        //{
        //    throw new NotImplementedException();
        //}

        public async Task<IEnumerable<Employee>> GetAllUserListByUserId(Guid userId)
        {
            var query = @"SELECT *
                        FROM [security].[Employee]
                        where UserId=@userId";
            var parameters = new Dictionary<string, object> { { "userId", userId } };
            return await Get(query, parameters);

        }
    }
}

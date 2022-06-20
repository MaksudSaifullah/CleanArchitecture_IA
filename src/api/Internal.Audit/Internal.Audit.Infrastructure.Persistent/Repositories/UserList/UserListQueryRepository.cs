using Internal.Audit.Application.Contracts.Persistent;
using Internal.Audit.Application.Contracts.Persistent.UserList;
using Internal.Audit.Application.Features.UserList.Queries.GetUserList;
using Internal.Audit.Domain.CompositeEntities;
using Internal.Audit.Domain.Entities.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internal.Audit.Infrastructure.Persistent.Repositories.UserList;
public class UserListQueryRepository : QueryRepositoryBase<CompositeUser>, IUserListQueryRepository
{
    public UserListQueryRepository(string _connectionString):base(_connectionString)
    {

    }
    public async Task<(long,IEnumerable<CompositeUser>)> GetAll(string userName, string employeeName, string userRole,int pageSize,int pageNumber)
    {
        var query = "EXEC [dbo].[GetUserListProcedure] @userName,@employeeName,@userRole,@pageSize,@pageNumber";
        var parameters = new Dictionary<string, object> { { "@userName", userName },{ "@employeeName", employeeName },{ "@userRole", userRole }, { "@pageSize", pageSize }, { "@pageNumber", pageNumber } };
        return await GetWithPagingInfo(query, parameters,false);
    }    
}

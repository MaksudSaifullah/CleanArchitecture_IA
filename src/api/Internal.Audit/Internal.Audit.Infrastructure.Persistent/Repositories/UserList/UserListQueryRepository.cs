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
    public async Task<IEnumerable<CompositeUser>> GetAll(string userName, string employeeName, string userRole)
    {
        var query = "EXEC [dbo].[GetUserListProcedure] @userName,@employeeName,@userRole";
        var parameters = new Dictionary<string, object> { { "@userName", userName },{ "@employeeName", employeeName },{ "@userRole", userRole } };
        return await Get(query, parameters);
    }

    public async Task<CompositeUser> GetById(Guid id)
    {
        var query = "SELECT [DesignationId],[UserName],[Password],[IsEnabled],[IsAccountExpired],[IsPasswordExpired]," +
            "[IsAccountLocked] FROM [security].[User] WHERE DesignationId=@id AND [IsDeleted] = 0";
        var parameters = new Dictionary<string, object> { { "id", id } };

        return await Single(query, parameters);
    }

    
}

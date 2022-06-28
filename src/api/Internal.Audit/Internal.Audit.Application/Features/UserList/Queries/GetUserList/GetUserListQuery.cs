using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internal.Audit.Application.Features.UserList.Queries.GetUserList;
public class GetUserListQuery:IRequest<UserListWithPagingInfoDTO>{
    public int pageSize { get; set; }
    public int pageNumber { get; set; }
    //public string userName { get; set; }
    //public string employeeName { get; set; }
    //public string userRole { get; set; }
    public UserSearchTerm searchTerm { get; set; }  

}

public class UserSearchTerm
{
    public string UserName { get; set; }
    public string EmployeeName { get; set; }
    public string UserRole { get; set; }
}


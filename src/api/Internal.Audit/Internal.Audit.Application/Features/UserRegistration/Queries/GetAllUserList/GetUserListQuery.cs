using Internal.Audit.Application.Features.UserList.Queries.GetUserList;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internal.Audit.Application.Features.UserRegistration.Queries.GetAllUserList
{
    public record GetUserListQuery :IRequest<IEnumerable<GetUserListResponseDTO>>;
    
}

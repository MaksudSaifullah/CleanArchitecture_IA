using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internal.Audit.Application.Features.UserList.Queries.GetUserList;
public record GetUserListQuery(string userName, string employeeName, string userRole) : IRequest<List<GetUserListResponseDTO>>;


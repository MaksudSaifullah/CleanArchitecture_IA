using AutoMapper;
using Internal.Audit.Application.Contracts.Persistent.UserList;
using Internal.Audit.Domain.CompositeEntities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internal.Audit.Application.Features.UserList.Queries.GetUserList;
public class GetUserListQueryHandler : IRequestHandler<GetUserListQuery, UserListWithPagingInfoDTO>
{
    private readonly IUserListQueryRepository _userListRepository;
    
    private readonly IMapper _mapper;

    public GetUserListQueryHandler(IUserListQueryRepository userListRepository,  IMapper mapper)
    {
        _userListRepository=userListRepository;
        _mapper =mapper;
    }
    public async Task<UserListWithPagingInfoDTO> Handle(GetUserListQuery request, CancellationToken cancellationToken)
    {
         var (count, result) = await _userListRepository.GetAll(request.userName, request. employeeName, request.userRole, request.pageSize,request.pageNumber);

         var userList =  _mapper.Map<IEnumerable<CompositeUser>, IEnumerable<GetUserListResponseDTO>>(result).ToList();

        return new UserListWithPagingInfoDTO { UserList = userList , TotalCount = count};
    }
}

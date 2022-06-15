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
public class GetUserListQueryHandler : IRequestHandler<GetUserListQuery, List<GetUserListResponseDTO>>
{
    private readonly IUserListQueryRepository _userListRepository;
    
    private readonly IMapper _mapper;

    public GetUserListQueryHandler(IUserListQueryRepository userListRepository,  IMapper mapper)
    {
        _userListRepository=userListRepository;
        _mapper =mapper;
    }
    public async Task<List<GetUserListResponseDTO>> Handle(GetUserListQuery request, CancellationToken cancellationToken)
    {
         var users = await _userListRepository.GetAll(request.userName, request. employeeName, request.userRole);
         return  _mapper.Map<IEnumerable<CompositeUser>, IEnumerable<GetUserListResponseDTO>>(users).ToList(); 
    }
}

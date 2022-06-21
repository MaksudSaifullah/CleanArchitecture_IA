using AutoMapper;
using Internal.Audit.Application.Contracts.Persistent.UserRegistration;
using Internal.Audit.Application.Features.UserList.Queries.GetUserList;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internal.Audit.Application.Features.UserRegistration.Queries.GetAllUserList
{
    public class GetUserListQueryHandler : IRequestHandler<GetUserListQuery, IEnumerable<GetUserListResponseDTO>>
    {
        private readonly IUserQueryRepository _userQueryRepository;
        private readonly IMapper _mapper;
        public GetUserListQueryHandler(IUserQueryRepository userQueryRepository, IMapper mapper)
        {
            _userQueryRepository= userQueryRepository ?? throw new ArgumentNullException(nameof(userQueryRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }
        public async Task<IEnumerable<GetUserListResponseDTO>> Handle(GetUserListQuery request, CancellationToken cancellationToken)
        {
            var userList =await  _userQueryRepository.GetAllUserList();
            return _mapper.Map<IEnumerable<GetUserListResponseDTO>>(userList);
        }
    }
}

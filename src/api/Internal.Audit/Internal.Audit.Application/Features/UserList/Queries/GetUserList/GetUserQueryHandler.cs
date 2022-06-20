using AutoMapper;
using Internal.Audit.Application.Contracts.Persistent.UserList;
using Internal.Audit.Domain.CompositeEntities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internal.Audit.Application.Features.UserList.Queries.GetUserList
{
    public class GetUserQueryHandler : IRequestHandler<GetUserQuery, GetUserListResponseDTO>
    {
        private readonly IUserQueryRepository _userRepository;

        private readonly IMapper _mapper;
        public GetUserQueryHandler(IUserQueryRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }
        public async Task<GetUserListResponseDTO> Handle(GetUserQuery request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetById(request.userId);
            return _mapper.Map<CompositeUser, GetUserListResponseDTO>(user);
        }
    }
}

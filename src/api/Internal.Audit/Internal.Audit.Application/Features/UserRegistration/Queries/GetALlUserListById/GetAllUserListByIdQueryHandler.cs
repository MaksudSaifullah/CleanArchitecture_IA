using AutoMapper;
using Internal.Audit.Application.Contracts.Persistent.UserRegistration;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internal.Audit.Application.Features.UserRegistration.Queries.GetALlUserListById
{
    public class GetAllUserListByIdQueryHandler : IRequestHandler<GetAllUserListByIdQuery, GetALlUserListByIdResponseDTO>
    {
        private readonly IUserQueryRepository _userQueryRepository;
        private readonly IMapper _mapper;
        public GetAllUserListByIdQueryHandler(IUserQueryRepository userQueryRepository, IMapper mapper)
        {
            _userQueryRepository = userQueryRepository ?? throw new ArgumentNullException(nameof(userQueryRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }
        public async Task<GetALlUserListByIdResponseDTO> Handle(GetAllUserListByIdQuery request, CancellationToken cancellationToken)
        {
            var userList = await _userQueryRepository.GetAllUserListById(request.userId);
            return _mapper.Map<GetALlUserListByIdResponseDTO>(userList);
        }
    }
}

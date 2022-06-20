using AutoMapper;
using Internal.Audit.Application.Contracts.Persistent;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internal.Audit.Application.Features.UserList.Commands.UpdateUser
{
    public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, UpdateUserResponseDTO>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IUserCommandRepository _userRepository;

        private readonly IMapper _mapper;
        public UpdateUserCommandHandler(IUserCommandRepository userRepository, IMapper mapper, IUnitOfWork unitOfWork)
        {
            _userRepository = userRepository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }
        public async Task<UpdateUserResponseDTO> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.Get(request.Id);
            var mappedUser = _mapper.Map(request, user);
            var updatedUser = await _userRepository.Update(mappedUser);
            var rowsAffected = await _unitOfWork.CommitAsync();
            return new UpdateUserResponseDTO(updatedUser.Id, rowsAffected > 0, rowsAffected > 0 ? "User Blocked Successfully!" : "Error while blocking user!");
        }
    }
}

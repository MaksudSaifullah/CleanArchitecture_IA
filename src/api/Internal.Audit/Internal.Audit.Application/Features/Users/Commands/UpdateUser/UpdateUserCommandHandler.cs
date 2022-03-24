
using AutoMapper;
using Internal.Audit.Application.Contracts.Persistent;
using Internal.Audit.Application.Features.Users.Commands.AddUser;
using Internal.Audit.Domain.Entities;
using MediatR;

namespace Internal.Audit.Application.Features.Users.Commands.UpdateUser;

public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, UpdateUserResponseDTO>
{
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;

    public UpdateUserCommandHandler(IUserRepository userRepository, IMapper mapper)
    {
        _userRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
    }

    public async Task<UpdateUserResponseDTO> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
    {
        var user = _mapper.Map<User>(request);
        var modifiedUser = await _userRepository.Update(user);
        return new UpdateUserResponseDTO(modifiedUser.Id, modifiedUser.Id > 0, modifiedUser.Id > 0 ? "User Updated Successfully!" : "Error while updating user!");
    }
}

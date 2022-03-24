
using AutoMapper;
using Internal.Audit.Application.Contracts.Persistent;
using Internal.Audit.Domain.Entities;
using MediatR;

namespace Internal.Audit.Application.Features.Users.Commands.AddUser;

public class AddUserCommandHandler : IRequestHandler<AddUserCommand, AddUserResponseDTO>
{
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;

    public AddUserCommandHandler(IUserRepository userRepository, IMapper mapper)
    {
        _userRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
    }

    public async Task<AddUserResponseDTO> Handle(AddUserCommand request, CancellationToken cancellationToken)
    {
        var user = _mapper.Map<User>(request);
        var newUser = await _userRepository.Add(user);
        return new AddUserResponseDTO(newUser.Id, newUser.Id > 0, newUser.Id > 0 ? "User Added Successfully!" : "Error while adding user!");
    }
}

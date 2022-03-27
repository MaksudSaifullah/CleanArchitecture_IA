
using AutoMapper;
using Internal.Audit.Application.Contracts.Persistent;
using Internal.Audit.Domain.Entities;
using MediatR;

namespace Internal.Audit.Application.Features.Users.Commands.AddUser;

public class AddUserCommandHandler : IRequestHandler<AddUserCommand, AddUserResponseDTO>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;

    public AddUserCommandHandler(IUserRepository userRepository, IMapper mapper, IUnitOfWork unitOfWork)
    {
        _userRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
    }

    public async Task<AddUserResponseDTO> Handle(AddUserCommand request, CancellationToken cancellationToken)
    {
        var user = _mapper.Map<User>(request);
        var newUser = await _userRepository.Add(user);
        var rowsAffected = await _unitOfWork.CommitAsync();
        return new AddUserResponseDTO(newUser.Id, rowsAffected > 0, rowsAffected > 0 ? "User Added Successfully!" : "Error while adding user!");
    }
}

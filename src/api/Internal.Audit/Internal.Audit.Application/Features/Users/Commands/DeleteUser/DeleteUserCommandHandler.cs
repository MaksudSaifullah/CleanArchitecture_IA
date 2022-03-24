
using AutoMapper;
using Internal.Audit.Application.Contracts.Persistent;
using MediatR;

namespace Internal.Audit.Application.Features.Users.Commands.DeleteUser;

public class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommand, DeleteUserResponseDTO>
{
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;

    public DeleteUserCommandHandler(IUserRepository userRepository, IMapper mapper)
    {
        _userRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
    }

    public async Task<DeleteUserResponseDTO> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
    {
        var result = await _userRepository.Delete(request.Id);
        return new DeleteUserResponseDTO(request.Id, result, result ? "User Deleted Successfully!" : "Error while deleting user!");
    }
}

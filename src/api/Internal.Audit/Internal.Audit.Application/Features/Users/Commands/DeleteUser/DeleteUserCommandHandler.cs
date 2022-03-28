
using AutoMapper;
using Internal.Audit.Application.Contracts.Persistent;
using MediatR;

namespace Internal.Audit.Application.Features.Users.Commands.DeleteUser;

public class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommand, DeleteUserResponseDTO>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IUserCommandRepository _userRepository;

    public DeleteUserCommandHandler(IUserCommandRepository userRepository, IUnitOfWork unitOfWork)
    {
        _userRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository));
        _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
    }

    public async Task<DeleteUserResponseDTO> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
    {
        var result = await _userRepository.Delete(request.Id);
        var rowsAffected = await _unitOfWork.CommitAsync();
        return new DeleteUserResponseDTO(request.Id, rowsAffected> 0, rowsAffected > 0 ? "User Deleted Successfully!" : "Error while deleting user!");
    }
}

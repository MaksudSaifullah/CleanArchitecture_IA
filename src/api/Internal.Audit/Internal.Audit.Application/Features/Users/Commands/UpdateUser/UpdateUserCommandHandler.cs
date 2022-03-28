
using AutoMapper;
using Internal.Audit.Application.Contracts.Persistent;
using Internal.Audit.Application.Features.Users.Commands.AddUser;
using Internal.Audit.Domain.Entities;
using MediatR;

namespace Internal.Audit.Application.Features.Users.Commands.UpdateUser;

public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, UpdateUserResponseDTO>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IUserCommandRepository _userRepository;
    private readonly IMapper _mapper;

    public UpdateUserCommandHandler(IUserCommandRepository userRepository, IMapper mapper, IUnitOfWork unitOfWork)
    {
        _userRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
    }

    public async Task<UpdateUserResponseDTO> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
    {
        var user = _mapper.Map<User>(request);
        var modifiedUser = await _userRepository.Update(user);
        var rowsAffected = await _unitOfWork.CommitAsync();
        return new UpdateUserResponseDTO(modifiedUser.Id, rowsAffected > 0, rowsAffected > 0 ? "User Updated Successfully!" : "Error while updating user!");
    }
}

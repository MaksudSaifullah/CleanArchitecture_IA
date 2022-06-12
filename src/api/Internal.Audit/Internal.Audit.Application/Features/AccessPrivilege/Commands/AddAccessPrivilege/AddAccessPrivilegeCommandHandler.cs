using AutoMapper;
using Internal.Audit.Application.Contracts.Persistent;
using Internal.Audit.Application.Contracts.Persistent.AccessPrivilege;
using Internal.Audit.Domain.Entities.security;
using MediatR;

namespace Internal.Audit.Application.Features.AccessPrivilege.Commands.AddAccessPrivilege;
public class AddAccessPrivilegeCommandHandler : IRequestHandler<AddAccessPrivilegeCommand, AddAccessPrivilegeResponseDTO>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IPasswordPolicyCommandRepository _passwordPolicyRepository;
    private readonly IUserLockingPolicyCommandRepository _userLockingPolicyRepository;
    private readonly ISessionPolicyCommandRepository _sessionPolicyRepository;
    private readonly IMapper _mapper;

    public AddAccessPrivilegeCommandHandler(IPasswordPolicyCommandRepository passwordPolicyRepository, 
        IUserLockingPolicyCommandRepository userLockingPolicyRepository,
        ISessionPolicyCommandRepository sessionPolicyRepository, 
        IMapper mapper, IUnitOfWork unitOfWork)
    {
        _passwordPolicyRepository = passwordPolicyRepository ?? throw new ArgumentNullException(nameof(passwordPolicyRepository));
        _userLockingPolicyRepository = userLockingPolicyRepository ?? throw new ArgumentNullException(nameof(userLockingPolicyRepository));
        _sessionPolicyRepository = sessionPolicyRepository ?? throw new ArgumentNullException(nameof(sessionPolicyRepository));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
    }
    public async Task<AddAccessPrivilegeResponseDTO> Handle(AddAccessPrivilegeCommand request, CancellationToken cancellationToken)
    {
        var passwordPolicy = _mapper.Map<PasswordPolicy>(request.PasswordPolicy);
        var newPasswordPolicy = await _passwordPolicyRepository.Add(passwordPolicy);

        var userLockingPolicy = _mapper.Map<UserLockingPolicy>(request.UserLockingPolicy);
        var newUserLockingPolicy = await _userLockingPolicyRepository.Add(userLockingPolicy);

        var sessionPolicy = _mapper.Map<SessionPolicy>(request.SessionPolicy);
        var newSessionPolicy = await _sessionPolicyRepository.Add(sessionPolicy);
        
        var rowsAffected = await _unitOfWork.CommitAsync();

        return new AddAccessPrivilegeResponseDTO(newPasswordPolicy.Id, rowsAffected > 0, "Access Privilege Added Successfully!" );
    }
}
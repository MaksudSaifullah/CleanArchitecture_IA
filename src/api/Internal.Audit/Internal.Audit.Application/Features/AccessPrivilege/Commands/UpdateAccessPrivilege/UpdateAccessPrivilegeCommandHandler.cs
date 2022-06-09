using AutoMapper;
using Internal.Audit.Application.Contracts.Persistent;
using Internal.Audit.Application.Contracts.Persistent.AccessPrivilege;
using MediatR;

namespace Internal.Audit.Application.Features.AccessPrivilege.Commands.UpdateAccessPrivilege;
public class UpdateAccessPrivilegeCommandHandler : IRequestHandler<UpdateAccessPrivilegeCommand, UpdateAccessPrivilegeResponseDTO>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IPasswordPolicyCommandRepository _passwordPolicyRepository;
    private readonly IUserLockingPolicyCommandRepository _userLockingPolicyRepository;
    private readonly ISessionPolicyCommandRepository _sessionPolicyRepository;
    private readonly IMapper _mapper;

    public UpdateAccessPrivilegeCommandHandler(IPasswordPolicyCommandRepository passwordPolicyRepository,
        IUserLockingPolicyCommandRepository userLockingPolicyRepository,
        ISessionPolicyCommandRepository sessionPolicyRepository, IMapper mapper, IUnitOfWork unitOfWork)
    {
        _passwordPolicyRepository = passwordPolicyRepository ?? throw new ArgumentNullException(nameof(passwordPolicyRepository));
        _userLockingPolicyRepository = userLockingPolicyRepository ?? throw new ArgumentNullException(nameof(userLockingPolicyRepository));
        _sessionPolicyRepository = sessionPolicyRepository ?? throw new ArgumentNullException(nameof(sessionPolicyRepository));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
    }
    public async Task<UpdateAccessPrivilegeResponseDTO> Handle(UpdateAccessPrivilegeCommand request, CancellationToken cancellationToken)
    {

        var passwordPolicy = await _passwordPolicyRepository.Get(request.PasswordPolicy.Id);
        if (passwordPolicy==null)
            return new UpdateAccessPrivilegeResponseDTO(request.PasswordPolicy.Id, false, "Invalid Password policy Id");
        passwordPolicy = _mapper.Map(request.PasswordPolicy, passwordPolicy);
        await _passwordPolicyRepository.Update(passwordPolicy);

        var userLockingPolicy = await _userLockingPolicyRepository.Get(request.UserLockingPolicy.Id);
        if(userLockingPolicy==null)
            return new UpdateAccessPrivilegeResponseDTO(request.UserLockingPolicy.Id, false, "Invalid User Locking policy Id");
        userLockingPolicy = _mapper.Map(request.UserLockingPolicy, userLockingPolicy);
        await _userLockingPolicyRepository.Update(userLockingPolicy);

        var sessionPolicy = await _sessionPolicyRepository.Get(request.SessionPolicy.Id);
        if(sessionPolicy==null)
            return new UpdateAccessPrivilegeResponseDTO(request.SessionPolicy.Id, false, "Invalid session policy Id");
        sessionPolicy = _mapper.Map(request.SessionPolicy, sessionPolicy);
        await _sessionPolicyRepository.Update(sessionPolicy);
        
        var rowsAffected = await _unitOfWork.CommitAsync();
        return new UpdateAccessPrivilegeResponseDTO(passwordPolicy.Id, rowsAffected > 0, rowsAffected > 0 ? "Access Privilege Updated Successfully!" : "Error while updating access privilege!");
    }
}
using AutoMapper;
using Internal.Audit.Application.Contracts.Persistent.AccessPrivilege;
using Internal.Audit.Domain.Entities.security;
using MediatR;

namespace Internal.Audit.Application.Features.AccessPrivilege.Queries.GetAccessPrivilege;
public class GetAccessPrivilegeQueryHandler : IRequestHandler<GetAccessPrivilegeQuery, GetAccessPrivilegeDTO>
{
    private readonly IPasswordPolicyQueryRepository _passwordPolicyRepository;
    private readonly IUserLockingPolicyQueryRepository _userLockingPolicyRepository;
    private readonly ISessionPolicyQueryRepository _sessionPolicyRepository;
    private readonly IMapper _mapper;

    public GetAccessPrivilegeQueryHandler(IPasswordPolicyQueryRepository passwordPolicyRepository,
        IUserLockingPolicyQueryRepository userLockingPolicyRepository,
        ISessionPolicyQueryRepository sessionPolicyRepository, IMapper mapper)
    {
        _passwordPolicyRepository = passwordPolicyRepository ?? throw new ArgumentNullException(nameof(passwordPolicyRepository));
        _userLockingPolicyRepository = userLockingPolicyRepository ?? throw new ArgumentNullException(nameof(userLockingPolicyRepository));
        _sessionPolicyRepository = sessionPolicyRepository ?? throw new ArgumentNullException(nameof(sessionPolicyRepository));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
    }
    public async Task<GetAccessPrivilegeDTO> Handle(GetAccessPrivilegeQuery request, CancellationToken cancellationToken)
    {
        GetAccessPrivilegeDTO accessPrivilege = new GetAccessPrivilegeDTO();

        var passwordPolicy = await _passwordPolicyRepository.Get();
        accessPrivilege.PasswordPolicy = _mapper.Map<GetPasswordPolicyDTO>(passwordPolicy);

        var sessionPolicy = await _sessionPolicyRepository.Get();
        accessPrivilege.SessionPolicy = _mapper.Map<GetSessionPolicyDTO>(sessionPolicy);

        var userLockingPolicy = await _userLockingPolicyRepository.Get();
        accessPrivilege.UserLockingPolicy = _mapper.Map<GetUserLockingPolicyDTO>(userLockingPolicy);

        return accessPrivilege;
    }
}
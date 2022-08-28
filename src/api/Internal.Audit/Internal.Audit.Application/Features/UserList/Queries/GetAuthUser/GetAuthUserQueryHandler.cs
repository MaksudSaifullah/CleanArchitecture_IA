using Internal.Audit.Application.Contracts.Auth;
using Internal.Audit.Application.Contracts.Persistent.UserRegistration;
using MediatR;

namespace Internal.Audit.Application.Features.UserList.Queries.GetAuthUser;
public class GetAuthUserQueryHandler : IRequestHandler<GetAuthUserQuery, AuthUserDTO>
{
    private readonly IUserQueryRepository _userRepository;
    private readonly IJwtTokenService _jwtTokenService;

    public GetAuthUserQueryHandler(IUserQueryRepository userRepository, IJwtTokenService jwtTokenService)
    {
        _userRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository));
        _jwtTokenService = jwtTokenService ?? throw new ArgumentNullException(nameof(jwtTokenService));
    }

    public async Task<AuthUserDTO> Handle(GetAuthUserQuery request, CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetByUserEmail(request.Email, request.Password);
        if (user == null)
            return new AuthUserDTO { Success = false, Message = "Invalid Username or Password." };
        if (user.IsAccountLocked)
        {
            return new AuthUserDTO { Success = false, Message = "User Locked, Contact with System Admin" };
           
        }
        if (user.IsAccountExpired)
        {
            return new AuthUserDTO { Success = false, Message = "User Expired, Contact with System Admin" };
           
        }
        var token = _jwtTokenService.GenerateJwtToken(user.UserName, "ADMIN");

        return new AuthUserDTO { Success = true, UserName = user.UserName, Name = "", Role = "ADMIN", Token = token };

    }
}


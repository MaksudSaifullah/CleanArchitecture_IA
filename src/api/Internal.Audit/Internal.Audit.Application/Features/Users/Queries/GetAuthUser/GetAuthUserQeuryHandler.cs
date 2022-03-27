
using Internal.Audit.Application.Contracts.Auth;
using Internal.Audit.Application.Contracts.Persistent;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using System.Text;

namespace Internal.Audit.Application.Features.Users.Queries.GetAuthUser;

public class GetAuthUserQeuryHandler : IRequestHandler<GetAuthUserQeury, AuthUserDTO>
{
    private readonly IUnitOfWork _uniOfWork;
    private readonly IUserRepository _userRepository;
    private readonly IJwtTokenService _jwtTokenService;

    public GetAuthUserQeuryHandler(IUserRepository userRepository, IJwtTokenService jwtTokenService, IUnitOfWork unitOfWork)
    {
        _userRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository));
        _jwtTokenService = jwtTokenService ?? throw new ArgumentNullException(nameof(jwtTokenService));
        _uniOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
    }

    public async Task<AuthUserDTO> Handle(GetAuthUserQeury request, CancellationToken cancellationToken)
    {
        var user = (await _userRepository.Get(u => u.Email.Equals(request.Email) && u.Password.Equals(request.Password))).FirstOrDefault();
        var rowsAffected = await _uniOfWork.CommitAsync();
        if (user == null)
            return new AuthUserDTO { Success = false };

        var token = _jwtTokenService.GenerateJwtToken(user.Email, "ADMIN");

        return new AuthUserDTO { Success = true, Email = user.Email, Name = "", Role = "ADMIN", Token = token };

    }
}

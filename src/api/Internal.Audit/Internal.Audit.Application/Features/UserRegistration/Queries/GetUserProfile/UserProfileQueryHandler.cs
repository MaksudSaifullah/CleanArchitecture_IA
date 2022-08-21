using Internal.Audit.Application.Contracts.Auth;
using Internal.Audit.Application.Contracts.Persistent.UserRegistration;
using MediatR;

namespace Internal.Audit.Application.Features.UserRegistration.Queries.GetUserProfile
{
    public class UserProfileQueryHandler : IRequestHandler<UserProfileQuery, UserProfileQueryResponseDTO>
    {
        internal readonly IUserProfileQueryRepository _userProfileRepository;
        internal readonly ICurrentAuthService _currentAuthService;

        public UserProfileQueryHandler(IUserProfileQueryRepository userProfileRepository, ICurrentAuthService currentAuthService)
        {
            _userProfileRepository = userProfileRepository;
            _currentAuthService = currentAuthService;
        }

        public async Task<UserProfileQueryResponseDTO> Handle(UserProfileQuery request, CancellationToken cancellationToken)
        {
            var currentUserEmail = _currentAuthService.Email;
            var user = await _userProfileRepository.GetByEmail(currentUserEmail);
            return new UserProfileQueryResponseDTO
            {
                ProfileImageUrl = user.ProfileImageUrl,
                FullName = user.FullName,
                DesignationName=user.Employee.Designation.Name,
                Id = user.Id,
                UserName=user.UserName,
            };
        }
    }
}

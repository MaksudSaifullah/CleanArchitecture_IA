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
          //  currentUserEmail = "sadsa";
            var user = await _userProfileRepository.GetByEmail(currentUserEmail);
            return new UserProfileQueryResponseDTO
            {
                ProfileImageUrl = user == null? "": user.ProfileImageUrl==null?"": user.ProfileImageUrl,
                FullName = user == null ? ""  : user.Employee == null ? "": user.Employee.Name == null ? "": user.Employee.Name,
                DesignationName= user == null ? "" : user.Employee == null ? "" : user.Employee.Designation == null? "": user.Employee.Designation.Name ==null? "": user.Employee.Designation.Name,
                Id = user == null ? Guid.NewGuid():user.Id,
                UserName= user == null ? "" : user.UserName,
            };
        }
    }
}

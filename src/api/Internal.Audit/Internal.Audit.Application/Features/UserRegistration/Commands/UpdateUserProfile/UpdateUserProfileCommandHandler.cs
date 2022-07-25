using Internal.Audit.Application.Contracts.Auth;
using Internal.Audit.Application.Contracts.Persistent.UserRegistration;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internal.Audit.Application.Features.UserRegistration.Commands.UpdateUserProfile
{
    public class UpdateUserProfileCommandHandler : IRequestHandler<UpdateUserProfileCommand, bool>
    {
        internal readonly IUserProfileUpdateRepository _userProfileCommandRepository;
        internal readonly ICurrentAuthService _currentAuthService;

        public UpdateUserProfileCommandHandler(IUserProfileUpdateRepository userProfileCommandRepository, ICurrentAuthService currentAuthService)
        {
            _userProfileCommandRepository = userProfileCommandRepository;
            _currentAuthService = currentAuthService;
        }

        public async Task<bool> Handle(UpdateUserProfileCommand request, CancellationToken cancellationToken)
        {
            var currentUserEmail = _currentAuthService.Email;
            var result = await _userProfileCommandRepository.UpdateUserProfile(currentUserEmail, request.FullName,request.ProfileImageUrl);
            return result;
        }
    }
}

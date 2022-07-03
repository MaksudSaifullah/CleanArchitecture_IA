using Internal.Audit.Application.Common.Security;
using Internal.Audit.Application.Contracts.Auth;
using Internal.Audit.Application.Contracts.Persistent.UserRegistration;
using MediatR;

namespace Internal.Audit.Application.Features.UserRegistration.Commands.ChangeUserPassword
{
    public class ChangePasswordCommandHandler : IRequestHandler<ChangeUserPasswordCommand, Tuple<bool, string>>
    {
        internal readonly IUserCommandRepository _userCommandRepository;
        internal readonly IUserQueryRepository _userQueryRepository;
        internal readonly ICurrentAuthService _currentAuthService;

        public ChangePasswordCommandHandler(ICurrentAuthService currentAuthService, IUserCommandRepository userCommandRepository, IUserQueryRepository userQueryRepository)
        {
            _currentAuthService = currentAuthService;
            _userCommandRepository = userCommandRepository;
            _userQueryRepository = userQueryRepository;
        }

        public async Task<Tuple<bool, string>> Handle(ChangeUserPasswordCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var user = await _userQueryRepository.GetByUserEmail(_currentAuthService.Email, request.CurrentPassword);
                if (user == null)
                {
                    throw new Exception("User not Found");
                }
                await _userCommandRepository.UpdateUserPassword(request.ConfirmPassword, user.Id);
                return new Tuple<bool, string>(true, "Password changed successfully");
            }
            catch (Exception ex)
            {
                return new Tuple<bool, string>(false, ex.Message);
            }
        }
    }
}

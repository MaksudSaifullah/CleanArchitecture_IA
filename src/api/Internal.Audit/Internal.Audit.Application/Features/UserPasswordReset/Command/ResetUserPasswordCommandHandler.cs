using Internal.Audit.Application.Contracts.Persistent.UserRegistration;
using MediatR;

namespace Internal.Audit.Application.Features.UserPasswordReset.Command
{
    public class ResetUserPasswordCommandHandler : IRequestHandler<ResetUserPasswordCommand, ResetUserPasswordCommandResponse>
    {
        private readonly IUserCommandRepository _userCommandRepository;
        private readonly IUserPasswordResetRepository _userPasswordResetRepository;

        public ResetUserPasswordCommandHandler(IUserCommandRepository userCommandRepository, IUserPasswordResetRepository userPasswordResetRepository)
        {
            _userCommandRepository = userCommandRepository;
            _userPasswordResetRepository = userPasswordResetRepository;
        }

        public async Task<ResetUserPasswordCommandResponse> Handle(ResetUserPasswordCommand request, CancellationToken cancellationToken)
        {
            var userId = await _userPasswordResetRepository.UserByValidPostCode(request.PostCode) ?? new Guid();
            if (userId != new Guid())
            {
                if (request.NewPassword == request.ConfirmPassword)
                    await _userCommandRepository.UpdateUserPassword(request.NewPassword, userId);
                else
                    return new ResetUserPasswordCommandResponse
                    {
                        Success = false,
                        Message = "New Password and Confirm password doesn't match"
                    };
            }
            else
                return new ResetUserPasswordCommandResponse
                {
                    Success = false,
                    Message = "Password Reset Link Expired"
                };
            return new ResetUserPasswordCommandResponse
            {
                Success = true,
                Message = "Password Reset Successful"
            };
        }
    }
}

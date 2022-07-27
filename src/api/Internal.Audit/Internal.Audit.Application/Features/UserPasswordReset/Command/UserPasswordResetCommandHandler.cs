using Internal.Audit.Application.Contracts.Persistent.UserRegistration;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Internal.Audit.Application.Features.UserPasswordReset.Command
{
    public class UserPasswordResetCommandHandler : IRequestHandler<UserPasswordResetCommand, UserPasswordResetCommandResponse>
    {
        private readonly IUserPasswordResetCommandRepository _userPasswordResetCommandRepository;
        private readonly IUserQueryRepository _userQueryRepository;

        public UserPasswordResetCommandHandler(IUserPasswordResetCommandRepository userPasswordResetCommandRepository, IUserQueryRepository userQueryRepository)
        {
            _userPasswordResetCommandRepository = userPasswordResetCommandRepository;
            _userQueryRepository = userQueryRepository;
        }

        public async Task<UserPasswordResetCommandResponse> Handle(UserPasswordResetCommand request, CancellationToken cancellationToken)
        {
            string random = string.Join("", Guid.NewGuid().ToString("n").Take(8).Select(o => o));
            var user = await _userQueryRepository.GetByUserEmail(request.Email);
            if (user == null)
            {
                return new UserPasswordResetCommandResponse()
                {
                    Success = false,
                    Message = "User not found by this email"
                };
            }
            await _userPasswordResetCommandRepository.UserPasswordResetCreate(user.Id, random);

            return new UserPasswordResetCommandResponse()
            {
                Success = true,
                Message = "A Password Reset Link is sent to your email"
            };
        }
       
    }
}

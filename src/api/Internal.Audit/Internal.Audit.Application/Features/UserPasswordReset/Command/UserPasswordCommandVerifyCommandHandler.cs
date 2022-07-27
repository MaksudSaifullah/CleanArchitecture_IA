using Internal.Audit.Application.Contracts.Persistent.UserRegistration;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internal.Audit.Application.Features.UserPasswordReset.Command
{
    public class UserPasswordCommandVerifyCommandHandler : IRequestHandler<UserPasswordCommandVerifyCommand, UserPasswordResetVerifyCommandResponse>
    {
        private readonly IUserPasswordResetCommandRepository _userPasswordResetCommandRepository;
        private readonly IUserPasswordResetRepository _userPasswordResetRepository;

        public UserPasswordCommandVerifyCommandHandler(IUserPasswordResetCommandRepository userPasswordResetCommandRepository, IUserPasswordResetRepository userPasswordResetRepository)
        {
            _userPasswordResetCommandRepository = userPasswordResetCommandRepository;
            _userPasswordResetRepository = userPasswordResetRepository;
        }

        public async Task<UserPasswordResetVerifyCommandResponse> Handle(UserPasswordCommandVerifyCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var isValidPreCode = await _userPasswordResetRepository.IsValidPreCode(request.EmailCode);
                string random = string.Join("", Guid.NewGuid().ToString("n").Take(8).Select(o => o));

                if (isValidPreCode)
                {
                    await _userPasswordResetCommandRepository.UserPasswordResetUpdatePostCode(request.EmailCode, random);
                    return new UserPasswordResetVerifyCommandResponse()
                    {
                        Success = true,
                        PostCode = random,
                    };
                }

            }
            catch (Exception ex)
            {
                return new UserPasswordResetVerifyCommandResponse()
                {
                    Success = false,
                    PostCode = null,
                };
            }
            return new UserPasswordResetVerifyCommandResponse()
            {
                Success = false,
                PostCode = null,
            };
        }
    }
}

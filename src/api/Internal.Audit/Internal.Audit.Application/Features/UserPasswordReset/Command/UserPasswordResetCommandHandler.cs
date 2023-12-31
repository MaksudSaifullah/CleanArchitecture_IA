﻿using Internal.Audit.Application.Contracts.Notifications;
using Internal.Audit.Application.Contracts.Persistent.UserRegistration;
using MediatR;
using Microsoft.Extensions.Configuration;
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
        private readonly IMailService _mailService;
        private readonly IConfiguration _configuration;

        public UserPasswordResetCommandHandler(IUserPasswordResetCommandRepository userPasswordResetCommandRepository, IUserQueryRepository userQueryRepository, IMailService mailService, IConfiguration configuration)
        {
            _userPasswordResetCommandRepository = userPasswordResetCommandRepository;
            _userQueryRepository = userQueryRepository;
            _mailService = mailService;
            _configuration = configuration;
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
            // email send for password reset
            _mailService.Setup(_configuration.GetValue<string>("MailSettings:DefaultSender"), new List<string>() { request.Email }, new List<string>(), true);
            _mailService.FormatSubject("Internal Audit Password Reset Instruction", "", new Dictionary<string, string>());
            _mailService.FormatBody($"<a href='{_configuration.GetValue<string>("ClientApplicationHost")}reset-password/{random}'>Reset Your Password</a>" + " <br /> " + " <br /> "
                + "After you click the link above, you'll be prompted to complete the following steps:" + " <br /> " + " <br /> "
                + "1. Enter new password " + " <br /> " 
                + "2. Confirm your new password " + "<br />" 
                + "3. Hit Submit" + " <br /> " + " <br /> "
                + " The link is valid for one time use only. It will expire in 5 minutes. "
                + " <br /> " +
                " This is a system generated mail. Please do not reply it."

                , "", new Dictionary<string, string>());
            await _mailService.SendAsync();

            return new UserPasswordResetCommandResponse()
            {
                Success = true,
                Message = "A Password Reset Link is sent to your email"
            };
        }
       
    }
}

//using Internal.Audit.Application.Features.Users.Queries.GetAuthUser;
using Internal.Audit.Application.Contracts.Auth;
using Internal.Audit.Application.Features.UserList.Queries.GetAuthUser;
using Internal.Audit.Application.Features.UserPasswordReset.Command;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Internal.Audit.Api.Controllers
{
    [Route("api/v{version:apiVersion}/authentication")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IGoogleRecatchaVerificationService _googleRecaptchaVerificationService;

        public AuthenticationController(IMediator mediator, IGoogleRecatchaVerificationService googleRecaptchaVerificationService)
        {
            _mediator = mediator;
            _googleRecaptchaVerificationService = googleRecaptchaVerificationService;
        }

        [HttpPost]
        public async Task<ActionResult<AuthUserDTO>> Get(GetAuthUserQuery query)
        {
            var captchaVerificationResult = await _googleRecaptchaVerificationService.ValidateRecaptchaV2(query.CaptchaToken);
            if (captchaVerificationResult.Item1 == true)
            {
                var result = await _mediator.Send(query);
                return Ok(result);
            }
            return Ok(new AuthUserDTO()
            {
                Success = captchaVerificationResult.Item1,
                Message = captchaVerificationResult.Item2
            });
            
        }

        [HttpPost(nameof(SendPasswordReset))]
        public async Task<ActionResult<UserPasswordResetCommandResponse>> SendPasswordReset(UserPasswordResetCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpPost(nameof(VerifyPasswordResetLink))]
        public async Task<ActionResult<UserPasswordResetVerifyCommandResponse>> VerifyPasswordResetLink(UserPasswordCommandVerifyCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }
        [HttpPost(nameof(UpdateUserPasswordByPostCode))]
        public async Task<ActionResult<ResetUserPasswordCommandResponse>> UpdateUserPasswordByPostCode(ResetUserPasswordCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }
    }
}

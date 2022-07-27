using MediatR;

namespace Internal.Audit.Application.Features.UserPasswordReset.Command
{
    public class ResetUserPasswordCommand : IRequest<ResetUserPasswordCommandResponse>
    {
        public string PostCode { get; set; }
        public string NewPassword { get; set; }
        public string ConfirmPassword { get; set; }
    }
}

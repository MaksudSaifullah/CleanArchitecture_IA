using MediatR;

namespace Internal.Audit.Application.Features.UserRegistration.Commands.ChangeUserPassword
{
    public class ChangeUserPasswordCommand : IRequest<Tuple<bool, string>>
    {
        public string CurrentPassword { get; set; } = string.Empty;
        public string NewPassword { get; set; } = string.Empty;
        public string ConfirmPassword { get; set; } = string.Empty;
    }
}

using FluentValidation;

namespace Internal.Audit.Application.Features.UserRegistration.Commands.ChangeUserPassword
{
    public class ChangeUserPasswordCommandValidator : AbstractValidator<ChangeUserPasswordCommand>
    {
        public ChangeUserPasswordCommandValidator()
        {
            RuleFor(x => x).Custom((x, context) =>
            {
                if (x.NewPassword != x.ConfirmPassword)
                {
                    context.AddFailure(nameof(x.NewPassword), "Passwords should match");
                }
            });

            RuleFor(p => p.NewPassword).MinimumLength(5).WithMessage("Minimum Password Length is 5 character");
            RuleFor(p => p.ConfirmPassword).MinimumLength(5).WithMessage("Minimum Password Length is 5 character");
            RuleFor(p => p.CurrentPassword).MinimumLength(5).WithMessage("Minimum Password Length is 5 character");

        }
    }
}

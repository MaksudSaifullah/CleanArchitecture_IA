
using FluentValidation;

namespace Internal.Audit.Application.Features.Users.Commands.UpdateUser;

public class UpdateUserCommandValidator: AbstractValidator<UpdateUserCommand>
{
    public UpdateUserCommandValidator()
    {
        CascadeMode = CascadeMode.Stop;

        RuleFor(u => u.Email)
            .NotEmpty().WithMessage("Email cannot be empty")
            .MaximumLength(50).WithMessage("Email address length cannot be more than 50 characters");

        RuleFor(u => u.Password)
            .NotEmpty().WithMessage("Password cannot be empty")
            .MaximumLength(15).WithMessage("Password length cannot be more than 15 characters")
            .MinimumLength(8).WithMessage("Password length cannot be less than 8 characters");
    }
}

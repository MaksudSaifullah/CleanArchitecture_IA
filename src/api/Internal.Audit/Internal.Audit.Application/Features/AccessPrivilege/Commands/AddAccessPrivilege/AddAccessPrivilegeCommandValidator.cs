using FluentValidation;

namespace Internal.Audit.Application.Features.AccessPrivilege.Commands.AddAccessPrivilege;
public class AddAccessPrivilegeCommandValidator : AbstractValidator<AddAccessPrivilegeCommand>
{
    public AddAccessPrivilegeCommandValidator()
    {
        CascadeMode = CascadeMode.Stop;
        //TODO: need to add validator if any
        //Rule demo, will remove later
        RuleFor(u => u.PasswordPolicy)
            .NotEmpty().WithMessage("Password Policy cannot be empty");
        RuleFor(u => u.UserLockingPolicy)
            .NotEmpty().WithMessage("User locking policy cannot be empty");
        RuleFor(u => u.SessionPolicy)
            .NotEmpty().WithMessage("Session Policy cannot be empty");

    }    
}

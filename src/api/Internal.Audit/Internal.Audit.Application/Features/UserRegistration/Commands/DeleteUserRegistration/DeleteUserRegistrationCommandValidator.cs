using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internal.Audit.Application.Features.UserRegistration.Commands.DeleteUserRegistration
{
    public class DeleteUserRegistrationCommandValidator : AbstractValidator<DeleteUserRegistrationCommand>
    {
        public DeleteUserRegistrationCommandValidator()
        {
            CascadeMode = CascadeMode.Stop;

            RuleFor(u => u.userId)
                .NotEmpty().WithMessage("User Id cannot be empty");
        }
    }
}

using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internal.Audit.Application.Features.UserRegistration.Commands.AddUserRegistration
{
    public class AddUserRegistrationCommandValidator : AbstractValidator<AddUserRegistrationCommand>
    {
        public AddUserRegistrationCommandValidator()
        {
            CascadeMode = CascadeMode.Stop;

            //RuleFor(u => u.Employee.Email)
            //    .NotEmpty().WithMessage("Email cannot be empty");
            //RuleFor(u => u.Employee.Name)
            //    .NotEmpty().WithMessage("Name cannot be empty");
            //RuleFor(u => u.Employee.PhotoId)
            //    .NotEmpty().WithMessage("PhotoId cannot be empty");
            //RuleFor(u => u.Employee.UserId)
            //   .NotEmpty().WithMessage("UserId cannot be empty");

            //RuleFor(u => u.User.UserName)
            //  .NotEmpty().WithMessage("UserName cannot be empty");
            //RuleFor(u => u.User.Password)
            //   .NotEmpty().WithMessage("Password cannot be empty");

        }
    }
}

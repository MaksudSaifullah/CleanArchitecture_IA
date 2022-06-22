using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internal.Audit.Application.Features.UserRegistration.Commands.DeleteUserRegistration
{
    public record DeleteUserRegistrationCommand(Guid userId):IRequest<DeleteUserRegistrationResponseDTO>;
    
}

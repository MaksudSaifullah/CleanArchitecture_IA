using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internal.Audit.Application.Features.UserRegistration.Commands.UpdateUserProfile
{
    public class UpdateUserProfileCommand : IRequest<bool>
    {
        public string FullName { get; set; } = null!;
        public string ProfileImageUrl { get; set; } = null!;
    }
}

﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internal.Audit.Application.Features.UserPasswordReset.Command
{
    public class UserPasswordResetCommand : IRequest<UserPasswordResetCommandResponse>
    {
        public string Email { get; set; } = null!;
    }
}

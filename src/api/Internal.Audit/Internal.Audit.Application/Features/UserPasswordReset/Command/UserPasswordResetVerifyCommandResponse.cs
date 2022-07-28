using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internal.Audit.Application.Features.UserPasswordReset.Command
{
    public class UserPasswordResetVerifyCommandResponse
    {
        public string? PostCode { get; set; }
        public bool Success { get; set; }
        public string Message { get; set; }
    }
}

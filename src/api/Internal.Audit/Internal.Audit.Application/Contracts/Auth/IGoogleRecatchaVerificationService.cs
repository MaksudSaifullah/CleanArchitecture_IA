using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internal.Audit.Application.Contracts.Auth
{
    public interface IGoogleRecatchaVerificationService
    {
        Task<(bool, string)> ValidateRecaptchaV2(string token);
    }
}

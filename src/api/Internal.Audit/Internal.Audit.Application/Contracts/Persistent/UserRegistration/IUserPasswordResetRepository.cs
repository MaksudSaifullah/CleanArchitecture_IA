using Internal.Audit.Domain.Entities.security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internal.Audit.Application.Contracts.Persistent.UserRegistration
{
    public interface IUserPasswordResetRepository : IAsyncQueryRepository<UserPasswordReset>
    {
        /// <summary>
        /// Password Rest Precode validate from Database
        /// </summary>
        /// <param name="preCode">Encoded Password Reset code came from Url</param>
        /// <returns></returns>
        Task<bool> IsValidPreCode(string preCode);
        /// <summary>
        /// Validate Password Reset Post Code
        /// </summary>
        /// <param name="postCode">Validate Post code with Url</param>
        /// <returns></returns>
        Task<Guid?> UserByValidPostCode(string preCode);
    }
}

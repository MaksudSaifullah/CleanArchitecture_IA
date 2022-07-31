using Internal.Audit.Domain.Entities.security;

namespace Internal.Audit.Application.Contracts.Persistent.UserRegistration
{
    public interface IUserPasswordResetCommandRepository : IAsyncCommandRepository<UserPasswordReset>
    {
        /// <summary>
        /// User Password Reset Precode 
        /// </summary>
        /// <param name="userId">User Id</param>
        Task UserPasswordResetCreate(Guid userId, string preCode);
        /// <summary>
        /// User Password Reset Post Code Generator
        /// </summary>
        /// <param name="preCode"></param>
        /// <param name="postCode"></param>
        /// <returns></returns>
        Task UserPasswordResetUpdatePostCode(string preCode, string postCode);

    }
}

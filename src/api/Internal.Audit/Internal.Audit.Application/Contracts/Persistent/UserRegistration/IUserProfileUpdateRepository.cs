using Internal.Audit.Domain.Entities.Security;

namespace Internal.Audit.Application.Contracts.Persistent.UserRegistration
{
    public interface IUserProfileUpdateRepository : IAsyncCommandRepository<User>
    {
        Task<bool> UpdateUserProfile(string email,string fullname, string profileImage);
    }
}

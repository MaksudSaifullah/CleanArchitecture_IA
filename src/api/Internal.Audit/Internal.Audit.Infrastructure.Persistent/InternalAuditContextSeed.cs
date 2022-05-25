
using Internal.Audit.Domain.Entities;

namespace Internal.Audit.Infrastructure.Persistent;

public class InternalAuditContextSeed
{
    public static async Task SeedAsync(InternalAuditContext context)
    {
        if (!context.Users.Any())
        { 
            context.Users.AddRange(GetSeedUsers());
            await context.SaveChangesAsync();
        }
    }

    private static IEnumerable<User> GetSeedUsers()
    {
        return new List<User>
        {
            new User
            {
                UserName = "Admin", Password = "@dmin123", IsPasswordExpired = false, IsEnabled = true, IsDeleted = false,
                IsAccountExpired = false, IsAccountLocked = false
            }

        };
    }
}

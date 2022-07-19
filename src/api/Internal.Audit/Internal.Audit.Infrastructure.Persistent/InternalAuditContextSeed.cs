
using Internal.Audit.Domain.Entities;
using Internal.Audit.Domain.Entities.config;
using Internal.Audit.Domain.Entities.Security;

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
        if (!context.DocumentSources.Any())
        {
            context.DocumentSources.AddRange(GetInitialDocumentSource());
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
    private static IEnumerable<DocumentSource> GetInitialDocumentSource()
    {
        return new List<DocumentSource>
        {
            new DocumentSource
            {
               Name ="Profile_Picture",CreatedBy="system",CreatedOn=DateTime.Now
            },
            new DocumentSource
            {
               Name ="Approval_Evidence",CreatedBy="system",CreatedOn=DateTime.Now
            },
             new DocumentSource
            {
               Name ="Review_Evidence",CreatedBy="system",CreatedOn=DateTime.Now
            },
              new DocumentSource
            {
               Name ="Testing_Sheets",CreatedBy="system",CreatedOn=DateTime.Now
            },
               new DocumentSource
            {
               Name ="Evidence_Details",CreatedBy="system",CreatedOn=DateTime.Now
            },

        };
    }
}

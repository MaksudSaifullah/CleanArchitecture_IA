
using Internal.Audit.Domain.Common;
using Internal.Audit.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Internal.Audit.Infrastructure.Persistent;

public class InternalAuditContext: DbContext
{
    public InternalAuditContext(DbContextOptions<InternalAuditContext> options): base(options)
    {
    }

    public DbSet<User> Users { get; set; }

    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        foreach (var entry in ChangeTracker.Entries<EntityBase>())
        {
            switch (entry.State)
            {
                case EntityState.Added:
                    entry.Entity.CreatedBy = "system"; //TODO: will change later
                    entry.Entity.CreatedOn = DateTime.Now;
                    break;
                case EntityState.Modified:
                    entry.Entity.LastModifiedBy = "system";
                    entry.Entity.LastModifiedOn = DateTime.Now;
                    break;
            }
        }
        return base.SaveChangesAsync(cancellationToken);
    }
}

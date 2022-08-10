
using Internal.Audit.Domain.Entities.common;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Internal.Audit.Infrastructure.Persistent.EFConfiguration;
public class DesignationConfiguration : BaseTypeConfiguration<Designation>
{
    public override void Configure(EntityTypeBuilder<Designation> builder)
    {
        base.Configure(builder);
        builder.HasIndex(c => c.Name).IsUnique();
    }
}
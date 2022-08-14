using Internal.Audit.Domain.Entities.security;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internal.Audit.Infrastructure.Persistent.EFConfiguration;

public class AmbsDataSyncConfiguration : BaseTypeConfiguration<AmbsDataSync>
{
    public override void Configure(EntityTypeBuilder<AmbsDataSync> builder)
    {
        base.Configure(builder);
        //builder.Properties<decimal>()
        // .HavePrecision(18, 6);


    }
}

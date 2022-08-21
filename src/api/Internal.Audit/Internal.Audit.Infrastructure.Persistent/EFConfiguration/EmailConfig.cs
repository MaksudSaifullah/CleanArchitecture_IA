using Internal.Audit.Domain.Entities.config;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internal.Audit.Infrastructure.Persistent.EFConfiguration
{
    public class EmailConfig: BaseTypeConfiguration<EmailConfiguration>
    {
        public override void Configure(EntityTypeBuilder<EmailConfiguration> builder)
        {
            base.Configure(builder);
            builder.HasIndex(c => c.EmailTypeId).IsUnique();
            builder.HasIndex(c => c.CountryId).IsUnique();
        }
    }
}

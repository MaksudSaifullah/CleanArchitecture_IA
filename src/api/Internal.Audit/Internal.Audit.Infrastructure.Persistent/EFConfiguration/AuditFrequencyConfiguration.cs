using Internal.Audit.Domain.Entities.BranchAudit;
using Internal.Audit.Domain.Entities.Config;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internal.Audit.Infrastructure.Persistent.EFConfiguration
{
    public class AuditFrequencyConfiguration : BaseTypeConfiguration<AuditFrequency>
    {
        public override void Configure(EntityTypeBuilder<AuditFrequency> builder)
        {
            base.Configure(builder);
            builder.HasOne<CommonValueAndType>(b => b.CommonValueAuditScoreType)
                  .WithMany()
                  .HasForeignKey(b => b.AuditScoreId)
                  .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne<CommonValueAndType>(b => b.CommonValueRatingType)
                 .WithMany()
                 .HasForeignKey(b => b.RatingTypeId)
                 .OnDelete(DeleteBehavior.NoAction);


            builder.HasOne<CommonValueAndType>(b => b.CommonValueAuditFrequencyType)
                 .WithMany()
                 .HasForeignKey(b => b.AuditFrequencyTypeId)
                 .OnDelete(DeleteBehavior.NoAction);
        }
    }
}

using Internal.Audit.Domain.Entities.BranchAudit;
using Internal.Audit.Domain.Entities.Common;
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
    public class RiskCriteriaConfiguration : BaseTypeConfiguration<RiskCriteria>
    {
        public override void Configure(EntityTypeBuilder<RiskCriteria> builder)
        {
            base.Configure(builder);
            builder.HasOne<CommonValueAndType>(b => b.CommonValueRiskCriteriaType)
                  .WithMany()
                  .HasForeignKey(b => b.RiskCriteriaTypeId)
                  .OnDelete(DeleteBehavior.NoAction);

            //builder.HasOne<CommonValueAndType>(b => b.CommonValueImpactType)
            //     .WithMany()
            //     .HasForeignKey(b => b.ImpactTypeId)
            //     .OnDelete(DeleteBehavior.NoAction);


            builder.HasOne<CommonValueAndType>(b => b.CommonValueRatingType)
                 .WithMany()
                 .HasForeignKey(b => b.RatingTypeId)
                 .OnDelete(DeleteBehavior.NoAction);
        }
    }
}

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
    public class RiskProfileConfiguration : BaseTypeConfiguration<RiskProfile>
    {
        public override void Configure(EntityTypeBuilder<RiskProfile> builder)
        {
            base.Configure(builder);
            builder.HasOne<CommonValueAndType>(b => b.CommonValueLikelihoodType)
                  .WithMany()
                  .HasForeignKey(b => b.LikelihoodTypeId)
                  .OnDelete(DeleteBehavior.NoAction);
           
            builder.HasOne<CommonValueAndType>(b => b.CommonValueImpactType)
                 .WithMany()
                 .HasForeignKey(b => b.ImpactTypeId)
                 .OnDelete(DeleteBehavior.NoAction);

           
            builder.HasOne<CommonValueAndType>(b => b.CommonValueRatingType)
                 .WithMany()
                 .HasForeignKey(b => b.RatingTypeId)
                 .OnDelete(DeleteBehavior.NoAction);                        
        }
    }
}

using Internal.Audit.Domain.Entities.Common;
using Internal.Audit.Domain.Entities.Config;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Internal.Audit.Domain.Entities.BranchAudit;

namespace Internal.Audit.Infrastructure.Persistent.EFConfiguration
{
   
    public class IssueConfiguration : BaseTypeConfiguration<Issue>
    {
        public override void Configure(EntityTypeBuilder<Issue> builder)
        {
            //base.Configure(builder);
            //builder.HasOne<CommonValueAndType>(b => b.CommonValueLikelihoodType)
            //      .WithMany()
            //      .HasForeignKey(b => b.LikelihoodTypeId)
            //      .OnDelete(DeleteBehavior.NoAction);

            //builder.HasOne<CommonValueAndType>(b => b.CommonValueImpactType)
            //     .WithMany()
            //     .HasForeignKey(b => b.ImpactTypeId)
            //     .OnDelete(DeleteBehavior.NoAction);


            //builder.HasOne<CommonValueAndType>(b => b.CommonValueRatingType)
            //     .WithMany()
            //     .HasForeignKey(b => b.RatingTypeId)
            //     .OnDelete(DeleteBehavior.NoAction);

            //builder.HasOne<CommonValueAndType>(b => b.CommonValueStatusType)
            //     .WithMany()
            //     .HasForeignKey(b => b.StatusTypeId)
            //     .OnDelete(DeleteBehavior.NoAction);
        }
    }
}

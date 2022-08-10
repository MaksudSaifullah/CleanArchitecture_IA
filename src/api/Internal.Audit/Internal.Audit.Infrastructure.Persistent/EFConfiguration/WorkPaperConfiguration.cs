using Internal.Audit.Domain.Entities.BranchAudit;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internal.Audit.Infrastructure.Persistent.EFConfiguration;
public class WorkPaperConfiguration : BaseTypeConfiguration<WorkPaper>
{
    public override void Configure(EntityTypeBuilder<WorkPaper> builder)
    {
        base.Configure(builder);

        //builder.HasMany<TopicHead>(x => x.Id)
        //        .WithOne<TopicHead>(x => x.Id)
        //        .OnDelete(DeleteBehavior.ClientSetNull);

        builder.HasOne<TopicHead>(b => b.TopicHead)
             .WithMany()
             .HasForeignKey(b => b.TopicHeadId)
             .OnDelete(DeleteBehavior.NoAction);


        //builder.HasOne<CommonValueAndType>(b => b.CommonValueImpactType)
        //     .WithMany()
        //     .HasForeignKey(b => b.ImpactTypeId)
        //     .OnDelete(DeleteBehavior.NoAction);


        //builder.HasOne<CommonValueAndType>(b => b.CommonValueRatingType)
        //     .WithMany()
        //     .HasForeignKey(b => b.RatingTypeId)
        //     .OnDelete(DeleteBehavior.NoAction);
    }
}

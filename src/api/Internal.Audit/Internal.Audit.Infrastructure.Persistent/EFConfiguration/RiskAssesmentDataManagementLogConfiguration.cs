using Internal.Audit.Domain.Entities.BranchAudit;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internal.Audit.Infrastructure.Persistent.EFConfiguration
{
    public class RiskAssesmentDataManagementLogConfiguration : BaseTypeConfiguration<RiskAssesmentDataManagementLog>
    {
        public override void Configure(EntityTypeBuilder<RiskAssesmentDataManagementLog> builder)
        {
            base.Configure(builder);
            builder.HasOne<RiskAssessment>(b => b.RiskAssessment)
                  .WithMany()
                  .HasForeignKey(b => b.RiskAssessmentId)
                  .OnDelete(DeleteBehavior.NoAction);

           
        }
    }
}

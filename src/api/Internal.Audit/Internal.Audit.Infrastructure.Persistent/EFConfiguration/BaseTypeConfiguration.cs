using Internal.Audit.Domain.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internal.Audit.Infrastructure.Persistent.EFConfiguration
{
    public class BaseTypeConfiguration<TItem> : IEntityTypeConfiguration<TItem> where TItem : EntityBase
    {
        public virtual void Configure(EntityTypeBuilder<TItem> builder)
        {
            
        }
    }
}

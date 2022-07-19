using Internal.Audit.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internal.Audit.Domain.CompositeEntities
{
    public class EmailType : EntityBase
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}

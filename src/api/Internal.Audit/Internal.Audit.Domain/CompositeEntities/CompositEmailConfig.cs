using Internal.Audit.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internal.Audit.Domain.CompositeEntities
{
    public class CompositEmailConfig: EntityBase
    {
        public Guid EmailTypeId { get; set; }
        public Guid CountryId { get; set; }
        public string TemplateSubject { get; set; }
        public string TemplateBody { get; set; }
        public string EmailTypeName { get; set; }
        public string CountryName { get; set; }
        public DateTime CreatedOn { get; set; }
    }
}

using Internal.Audit.Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internal.Audit.Domain.Entities.Config
{
    [Table("AuditYear", Schema = "Config")]
    public class AuditYear : EntityBase
    {
        [Required]        
        public Int32 Code { get; set; } 
    }
}

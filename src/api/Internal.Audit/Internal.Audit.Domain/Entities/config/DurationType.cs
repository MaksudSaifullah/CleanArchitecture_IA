using Internal.Audit.Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internal.Audit.Domain.Entities.config
{
    [Table("DurationType", Schema = "config")]
    public class DurationType : EntityBase
    {
        [Required]
        [MaxLength(20)]
        public string Name { get; set; } = null!;

        [Required]
        [MaxLength(10)]
        public string Type { get; set; } = null!;

        [Required]
        [MaxLength(10)]
        public string Remarks { get; set; } = null!;

        [Required]
        [DefaultValue("0")]
        public bool IsActive { get; set; }
    }
}

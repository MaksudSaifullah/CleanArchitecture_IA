using Internal.Audit.Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internal.Audit.Domain.Entities.common
{
    [Table("Designation", Schema = "Common")]
    public class Designation : EntityBase
    {
        [Required]
        [MaxLength(50)]
        public string Name { get; set; } = null!;

        [Required]
        [MaxLength(50)]
        public string Description { get; set; } = null!;

        [Required]
        [DefaultValue("1")]
        public bool IsActive { get; set; }
    }
}


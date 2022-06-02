
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
    [Table("Role", Schema = "common")]
    public class Role : EntityBase
    {
        [Required]
        [MaxLength(20)]
        public string Name { get; set; } = null!; // showing error for Role

 
        [MaxLength(250)]
        public string? Description { get; set; }

        [Required]
        [DefaultValue("1")]
        public bool IsActive { get; set; }


    }
}


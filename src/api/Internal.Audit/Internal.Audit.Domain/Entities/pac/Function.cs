using Internal.Audit.Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internal.Audit.Domain.Entities.pac
{
    [Table("Function", Schema = "pac")]
    public class Function : EntityBase
    {
        [Required]
        public Guid CountryId { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; } = null!;

        [Required]
        public DateTime EffectiveFrom { get; set; }

        [Required]
        public DateTime EffectiveTo { get; set; }

        [Required]
        [MaxLength(200)]
        public string Description { get; set; } = null!;

        //Navigation properties
        [ForeignKey("CountryId")]
        public virtual Country Country { get; set; } = null!;

    }
}

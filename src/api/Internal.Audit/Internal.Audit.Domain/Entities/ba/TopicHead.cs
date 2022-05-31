using Internal.Audit.Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internal.Audit.Domain.Entities.ba
{
    [Table("TopicHead", Schema = "ba")]
    public class TopicHead : EntityBase
    {
        [Required]
        public Guid CountryId { get; set; }

        [Required]
        [DefaultValue("1")]
        public bool IsActive { get; set; }

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

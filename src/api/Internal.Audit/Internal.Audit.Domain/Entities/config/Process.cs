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
    [Table("Process", Schema = "Config")]
    public class Process : EntityBase
    {
        [Required]
        public Guid AuditableFunctionId { get; set; }

        [Required]
        [MaxLength(20)]
        public string Name { get; set; } = null!;

        [Required]
        public DateTime EffeciveFrom { get; set; } 

        [Required]
        public DateTime EffectiveTo { get; set; } 

        [Required]
        [MaxLength(200)]
        public string Description { get; set; } = null!;

        //[ForeignKey("AuditableFunctionId")]
        //public virtual AuditableFunction AuditableFunction { get; set; } = null!;


    }
}

using Internal.Audit.Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internal.Audit.Domain.Entities;

[Table("TopicHead", Schema = "")]
public class TopicHead : EntityBase
{
    [Required]
    public Guid CountryId { get; set; }

    [Required]
    [DefaultValue("1")]
    public bool IsActive { get; set; }

    [Required]
    [MaxLength(100)]
    public string Name { get; set; }

    [Required]
    public DateTime EffectiveFrom { get; set; }
    [Required]
    public DateTime EffectiveTo { get; set; }

    [Required]
    [MaxLength(100)]
    public string Description { get; set; }

    [ForeignKey("CountryId")]
    public virtual Country Country { get; set; } = null!;
}
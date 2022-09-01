using Internal.Audit.Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internal.Audit.Domain.Entities.BranchAudit;


[Table("WeightScore", Schema = "BranchAudit")]
public class WeightScore : EntityBase
{
    [Required]
    public Guid CountryId { get; set; }

    [Required]
    public Guid TopicHeadId { get; set; }

    [Required]
    public decimal Score { get; set; }

    //[Required]
    //public DateTime EffectiveFrom { get; set; }
    //[Required]
    //public DateTime EffectiveTo { get; set; }

    //[ForeignKey("CountryId")]
    //public virtual Country Country { get; set; } = null!;

    [ForeignKey("TopicHeadId")]
    public virtual TopicHead TopicHead { get; set; } = null!;
}
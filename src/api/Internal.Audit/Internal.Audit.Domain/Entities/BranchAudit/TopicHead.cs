using Internal.Audit.Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internal.Audit.Domain.Entities.BranchAudit;

[Table("TopicHead", Schema = "BranchAudit")]
public class TopicHead : EntityBase
{
    [Required]
    public Guid CountryId { get; set; }

    [Required]
    [MaxLength(100)]
    public string Name { get; set; } = null!;

    [Required]
    public DateTime EffectiveFrom { get; set; }

    [Required]
    public DateTime EffectiveTo { get; set; }
    
    [MaxLength(300)]
    public string? Description { get; set; } = null!;

    [Required]
    [DefaultValue("1")]
    public bool IsActive { get; set; }
    [NotMapped]
    public string CountryName { get; set; } = null!;

    //Navigation properties
    [ForeignKey("CountryId")]
    public virtual Country Country { get; set; } = null!;
    [NotMapped]
    public virtual ICollection<WorkPaper> WorkPaperList { get; set; } = null!;

}

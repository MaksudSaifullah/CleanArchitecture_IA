using Internal.Audit.Domain.Common;
using Internal.Audit.Domain.Entities.BranchAudit;
using Internal.Audit.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internal.Audit.Domain.Entities.Config;

[Table("CommonValueAndType", Schema = "Config")]
public class CommonValueAndType : EntityBase
{
    [Required]
    [MaxLength(50)]
    public string Type { get; set; } = null!;

    [MaxLength(50)]
    public string SubType { get; set; } = null!;

    [Required]
    public Int32 Value { get; set; }

    [Required]
    [MaxLength(50)]
    public string Text { get; set; } = null!;

    [Required]
    [DefaultValue("1")]
    public bool IsActive { get; set; }

    [Required]
    public int SortOrder { get; set; }
    public ICollection<RiskProfile> RiskProfile { get; set; }

    public ICollection<RiskCriteria> RiskCriteria { get; set; }

}


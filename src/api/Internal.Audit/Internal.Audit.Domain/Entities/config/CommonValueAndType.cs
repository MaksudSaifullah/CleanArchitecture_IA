using Internal.Audit.Domain.Common;
using System;
using System.Collections.Generic;
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
    public int SortOrder { get; set; }
}


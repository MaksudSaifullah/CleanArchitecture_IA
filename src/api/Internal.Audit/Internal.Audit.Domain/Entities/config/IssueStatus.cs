using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internal.Audit.Domain.Entities.Config;

[Table("IssueStatus", Schema = "Config")]
public class IssueStatus
{
    [Required]
    [MaxLength(20)]
    public string Score { get; set; } = null!;
}



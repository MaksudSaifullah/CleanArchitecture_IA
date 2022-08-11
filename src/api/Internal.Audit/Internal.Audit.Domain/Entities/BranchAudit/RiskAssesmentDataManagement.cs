using Internal.Audit.Domain.Common;
using Internal.Audit.Domain.Entities.security;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internal.Audit.Domain.Entities.BranchAudit;
[Table("RiskAssesmentDataManagement", Schema = "BranchAudit")]
public class RiskAssesmentDataManagement:EntityBase
{   
    public float Value { get; set; }
    public int Score { get; set; }
    public string Rating { get; set; }
    public bool IsDraft { get; set; }
    public int BranchId { get; set; }
    public Guid RiskAssesmentDataManagementLogId { get; set; }
    [ForeignKey("RiskAssesmentDataManagementLogId")]
    public virtual RiskAssesmentDataManagementLog RiskAssesmentDataManagementLog { get; set; } = null!;
    [NotMapped]
    public virtual Branch Branch { get; set; }

}

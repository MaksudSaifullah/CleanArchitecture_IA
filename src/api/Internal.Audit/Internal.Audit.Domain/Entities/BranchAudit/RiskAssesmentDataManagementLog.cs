using Internal.Audit.Domain.Common;
using Internal.Audit.Domain.Entities.security;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internal.Audit.Domain.Entities.BranchAudit;
[Table("RiskAssesmentDataManagementLog", Schema = "BranchAudit")]
public class RiskAssesmentDataManagementLog:EntityBase
{
    public Guid DataRequestQueueServiceId { get; set; }
    public decimal ConversionRate { get; set; }
    public int TypeId { get; set; }
   
    [ForeignKey("DataRequestQueueServiceId")]
    public virtual DataRequestQueueService DataRequestQueueService { get; set; } = null!;

    public virtual ICollection<RiskAssesmentDataManagement> RiskAssesmentDataManagement { get; set; }=null!;

  
}

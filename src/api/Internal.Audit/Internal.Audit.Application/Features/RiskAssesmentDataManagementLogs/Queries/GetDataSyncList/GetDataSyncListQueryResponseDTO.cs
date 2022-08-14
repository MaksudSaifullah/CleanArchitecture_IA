using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internal.Audit.Application.Features.RiskAssesmentDataManagementLogs.Queries.GetDataSyncList;

public class GetDataSyncListQueryResponseDTO
{
    public Guid DataRequestQueueServiceId { get; set; }
    public decimal ConversionRate { get; set; }
    public int TypeId { get; set; }

   
    //public virtual DataRequestQueueService DataRequestQueueService { get; set; } = null!;

    //public virtual ICollection<RiskAssesmentDataManagement> RiskAssesmentDataManagement { get; set; } = null!;
}

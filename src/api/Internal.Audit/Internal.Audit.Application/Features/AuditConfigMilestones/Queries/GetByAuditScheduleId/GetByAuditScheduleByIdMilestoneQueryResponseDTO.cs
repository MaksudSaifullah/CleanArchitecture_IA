using Internal.Audit.Application.Features.CommonValueAndTypes.Queries.GetSampleSize;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internal.Audit.Application.Features.AuditConfigMilestones.Queries.GetByAuditScheduleId;

public class GetByAuditScheduleByIdMilestoneQueryResponseDTO
{
    public Guid AuditScheduleId { get; set; }
    public int CommonValueAuditConfigMilestoneId { get; set; }
    public DateTime? SetDate { get; set; }    
   
    public virtual SampleSizeDTO CommonValue { get; set; } = null!;
}

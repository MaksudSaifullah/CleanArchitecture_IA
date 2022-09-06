using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internal.Audit.Application.Features.AuditConfigMilestones.Commands.AddAuditConfigMilestones;

public class AddAuditConfigMilestoneCommand:IRequest<AddAuditConfigMilestoneResponseDTO>
{
    public List<AddAuditConfigMilestoneCommandRaw> Data { get; set; }
}

public class AddAuditConfigMilestoneCommandRaw
{
    public Guid AuditScheduleId { get; set; }
    public int CommonValueAuditConfigMilestoneId { get; set; }
    public DateTime SetDate { get; set; }
}

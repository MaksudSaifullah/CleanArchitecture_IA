using Internal.Audit.Application.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internal.Audit.Application.Features.AuditPlans.Commands.AddAuditPlan;

public record AddAuditPlanResponseDTO : BaseResponseDTO
{
    public AddAuditPlanResponseDTO(Guid Id, bool Success, string Message) : base(Id, Success, Message)
    {
    }
}
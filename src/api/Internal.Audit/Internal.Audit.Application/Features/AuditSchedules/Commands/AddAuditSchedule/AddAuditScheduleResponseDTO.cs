using Internal.Audit.Application.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internal.Audit.Application.Features.AuditSchedules.Commands.AddAuditSchedule;

public record AddAuditScheduleResponseDTO : BaseResponseDTO
{
    public AddAuditScheduleResponseDTO(Guid Id, bool Success, string Message) : base(Id, Success, Message)
    {
    }
}

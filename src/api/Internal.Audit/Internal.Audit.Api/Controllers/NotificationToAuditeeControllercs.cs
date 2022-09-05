using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Internal.Audit.Application.Features.AuditSchedules.Commands.UpdateSchedule;
using Internal.Audit.Application.Features.AuditSchedules.Commands.DeleteAuditSchedule;
using Internal.Audit.Application.Features.AuditSchedules.Queries.GetAuditScheduleByCreationId;

namespace Internal.Audit.Api.Controllers;

[Route("api/v{version:apiVersion}/NotificationToAuditee")]
[ApiController]
public class NotificationToAuditeeControllercs : ControllerBase
{

}
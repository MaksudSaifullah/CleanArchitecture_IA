using Internal.Audit.Application.Features.AuditSchedules.Commands.AddAuditSchedule;
using Internal.Audit.Application.Features.AuditSchedules.Queries.GetAuditScheduleList;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Internal.Audit.Api.Controllers;

[Route("api/v{version:apiVersion}/AuditSchedule")]
[ApiController]
public class AuditScheduleController : ControllerBase
{
    private readonly IMediator _mediator;
    public AuditScheduleController(IMediator madiator)
    {
        _mediator = madiator ?? throw new ArgumentNullException(nameof(madiator));
    }
    [HttpPost("paginated")]
    public async Task<ActionResult<GetAuditScheduleListPagingDTO>> GetList(GetAuditScheduleListQuery getAuditScheduleListQuery)
    {
        var auditSchedules = await _mediator.Send(getAuditScheduleListQuery);
        return Ok(auditSchedules);

    }
    [HttpPost]
    public async Task<ActionResult<AddAuditScheduleResponseDTO>> Add(AddAuditScheduleCommand command)
    {
        var result = await _mediator.Send(command);
        return Ok(result);
    }
}

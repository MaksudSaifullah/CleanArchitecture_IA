using Internal.Audit.Application.Features.Audit.Commands.AddAudit;
using Internal.Audit.Application.Features.Audit.Commands.DeleteAudit;
using Internal.Audit.Application.Features.Audit.Queries.GetAuditList;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Internal.Audit.Api.Controllers;
[Route("api/v{version:apiVersion}/audit")]
[ApiController]
public class AuditController : ControllerBase
{
    private readonly IMediator _mediator;
    public AuditController(IMediator madiator)
    {
        _mediator = madiator ?? throw new ArgumentNullException(nameof(madiator));
    }

    [HttpPost("paginated")]
    public async Task<ActionResult<GetAuditListPagingDTO>> GetList(GetAuditListQuery auditListQuery)
    {
        var audits = await _mediator.Send(auditListQuery);
        return Ok(audits);

    }

    [HttpPost]
    public async Task<ActionResult<AddAuditResponseDTO>> Add(AddAuditCommand command)
    {
        var result = await _mediator.Send(command);
        return Ok(result);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<DeleteAuditResponseDTO>> Delete(Guid id)
    {
        var command = new DeleteAuditCommand(id);
        var result = await _mediator.Send(command);
        return Ok(result);
    }
}

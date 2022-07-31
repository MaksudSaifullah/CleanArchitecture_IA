using Internal.Audit.Application.Features.Audit.Commands.AddAudit;
using Internal.Audit.Application.Features.Audit.Commands.DeleteAudit;
using Internal.Audit.Application.Features.Audit.Commands.UpdateAudit;
using Internal.Audit.Application.Features.Audit.Queries.GetAuditById;
using Internal.Audit.Application.Features.Audit.Queries.GetAuditList;
using Internal.Audit.Application.Features.Audit.Queries.GetAuditPlanCodeList;
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
    [HttpPost("paginatedAuditPlanCode")]
    public async Task<ActionResult<AuditPlanCodePagingDTO>> GetAuditPlanCodeList(GetAuditPlanCodeListQuery getAuditPlanCodeListQuery)
    {
        var auditPlanCodes = await _mediator.Send(getAuditPlanCodeListQuery);
        return Ok(auditPlanCodes);

    }
    [HttpGet("{Id}")]
    public async Task<ActionResult<GetAuditByIdResponseDTO>> GetById(Guid Id)
    {
        var query = new GetAuditQuery(Id);
        var audit = await _mediator.Send(query);
        return Ok(audit);
    }

    [HttpPost]
    public async Task<ActionResult<AddAuditResponseDTO>> Add(AddAuditCommand command)
    {
        var result = await _mediator.Send(command);
        return Ok(result);
    }
    [HttpPut]
    public async Task<ActionResult<UpdateAuditResponseDTO>> Update(UpdateAuditCommand command)
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

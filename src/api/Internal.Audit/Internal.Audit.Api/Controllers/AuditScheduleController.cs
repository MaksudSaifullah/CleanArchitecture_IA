using Internal.Audit.Application.Features.AuditSchedules.Commands.AddAuditSchedule;
using Internal.Audit.Application.Features.AuditSchedules.Queries.GetAuditScheduleBranchList;
using Internal.Audit.Application.Features.AuditSchedules.Queries.GetAuditScheduleByPlanId;
using Internal.Audit.Application.Features.AuditSchedules.Queries.GetAuditScheduleById;
using Internal.Audit.Application.Features.AuditSchedules.Queries.GetAuditScheduleList;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Internal.Audit.Application.Features.AuditSchedules.Commands.UpdateSchedule;
using Internal.Audit.Application.Features.AuditSchedules.Commands.DeleteAuditSchedule;
using Internal.Audit.Application.Features.AuditSchedules.Queries.GetAuditScheduleByCreationId;
using Internal.Audit.Application.Features.AuditScheduleConfigurationsOwner.Commands.AddAuditScheduleConfigurationsOwnerCommand;
using Internal.Audit.Application.Features.AuditScheduleConfigurationsOwner.Queries.GetAllByAuditScheduleId;

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
    [HttpGet("{Id}")]
    public async Task<ActionResult<AuditScheduleByIdDTO>> GetById(Guid Id)
    {
        var query = new GetAuditScheduleQuery(Id);
        var auditSchedules = await _mediator.Send(query);
        return Ok(auditSchedules);

    }
    [HttpPost("paginatedScheduleBranch")]
    public async Task<ActionResult<GetAuditScheduleListPagingDTO>> GetScheduleBranch(GetAuditScheduleBranchListQuery getAuditScheduleBranchListQuery)
    {
        var auditScheduleBranches = await _mediator.Send(getAuditScheduleBranchListQuery);
        return Ok(auditScheduleBranches);

    }
    [HttpPost]
    public async Task<ActionResult<AddAuditScheduleResponseDTO>> Add(AddAuditScheduleCommand command)
    {
        var result = await _mediator.Send(command);
        return Ok(result);
    }
    [HttpPut]
    public async Task<ActionResult<UpdateScheduleResponseDTO>> Update(UpdateScheduleCommand command)
    {
        var result = await _mediator.Send(command);
        return Ok(result);
    }
    [HttpDelete("{Id}")]
    public async Task<ActionResult<DeleteAuditScheduleResponseDTO>> Delete(Guid Id)
    {
        DeleteAuditScheduleCommand command = new DeleteAuditScheduleCommand(Id);
        var result = await _mediator.Send(command);
        return Ok(result);
    }
    [HttpPost("getScheduleId")]
    public async Task<ActionResult<GetAuditSchedulePlanIdResponseDTO>> GetScheduleId(GetAuditScheduleByPlanIdQuery command)
    {
        var result = await _mediator.Send(command);
        return Ok(result);
    }

    [HttpPost("getByAuditCreationId")]
    public async Task<ActionResult<GetAuditSchedulePlanIdResponseDTO>> GetByAuditCreationId(GetAuditScheduleByCreationIdQuery query)
    {
        var result = await _mediator.Send(query);
        return Ok(result);
    }

    [HttpPost("AuditScheudleConfigurationOwner")]
    public async Task<ActionResult<AuditScheduleConfiurationsOwnerCommandResponseDTO>> AddAuditScheudleConfigurationOwner(AddAuditScheduleConfigurationsOwnerCommand command)
    {
        var result = await _mediator.Send(command);
        return Ok(result);
    }
    [HttpGet("AuditScheudleConfigurationOwnerGetByScheduleId")]
    public async Task<ActionResult<GetAllByAuditScheduledIdResponseDTO>> AuditScheudleConfigurationOwnerGetByScheduleId(Guid? AuditSCheduleId,int TypeId)
    {
        var result = await _mediator.Send(new GetAllByAuditScheduleIdQuery(AuditSCheduleId,TypeId));
        return Ok(result);
    }
}

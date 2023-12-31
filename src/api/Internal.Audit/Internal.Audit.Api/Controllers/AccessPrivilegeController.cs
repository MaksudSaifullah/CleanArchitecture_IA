﻿using Internal.Audit.Application.Features.AccessPrivilege.Commands.AddAccessPrivilege;
using Internal.Audit.Application.Features.AccessPrivilege.Commands.UpdateAccessPrivilege;
using Internal.Audit.Application.Features.AccessPrivilege.Queries.GetAccessPrivilege;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Internal.Audit.Api.Controllers;
[Route("api/v{version:apiVersion}/accessPrivilege")]
[ApiController]
public class AccessPrivilegeController : ControllerBase
{
    private readonly IMediator _mediator;
    public AccessPrivilegeController(IMediator madiator)
    {
        _mediator = madiator ?? throw new ArgumentNullException(nameof(madiator));
    }
    [HttpGet]
    public async Task<ActionResult<GetAccessPrivilegeDTO>> Get()
    {
        var query = new GetAccessPrivilegeQuery();
        var accessPrivilege = await _mediator.Send(query);
        return Ok(accessPrivilege);

    }

    [HttpPost]
    public async Task<ActionResult<AddAccessPrivilegeResponseDTO>> Add(AddAccessPrivilegeCommand command)
    {
        var result = await _mediator.Send(command);
        return Ok(result);
    }

    [HttpPut]
    public async Task<ActionResult<UpdateAccessPrivilegeResponseDTO>> Update(UpdateAccessPrivilegeCommand command)
    {
        var result = await _mediator.Send(command);
        return Ok(result);
    }
}

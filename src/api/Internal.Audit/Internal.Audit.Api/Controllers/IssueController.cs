using Internal.Audit.Application.Features.Issues.Commands.AddIssue;
using Internal.Audit.Application.Features.Issues.Commands.DeleteIssue;
using Internal.Audit.Application.Features.Issues.Commands.UpdateIssue;
using Internal.Audit.Application.Features.Issues.Queries.GetIssueById;
using Internal.Audit.Application.Features.Issues.Queries.GetIssueList;
using MediatR;
//using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;

namespace Internal.Audit.Api.Controllers;

[Route("api/v{version:apiVersion}/issue")]
[ApiController]
public class IssueController : ControllerBase
{
    private readonly IMediator _mediator;
    public IssueController(IMediator madiator)
    {
        _mediator = madiator ?? throw new ArgumentNullException(nameof(madiator));
    }

    [HttpPost("paginated")]
    public async Task<ActionResult<GetIssueListPagingDTO>> GetList(GetIssueListQuery getIssueListQuery)
    {
        var result = await _mediator.Send(getIssueListQuery);
        return Ok(result);
    }

    [HttpGet("id")]
    public async Task<ActionResult<GetIssueByIdResponseDTO>> GetById(Guid Id)
    {
        var query = new GetIssueByIdQuery(Id);
        var result = await _mediator.Send(query);
        return Ok(result);
    }

    [HttpPost]
    public async Task<ActionResult<AddIssueResponseDTO>> Add(AddIssueCommand command)
    {
        var result = await _mediator.Send(command);
        return Ok(result);
    }

    [HttpPut]
    public async Task<ActionResult<UpdateIssueResponseDTO>> Update(UpdateIssueCommand command)
    {
        var result = await _mediator.Send(command);
        return Ok(result);
    }

    [HttpDelete("id")]
    public async Task<ActionResult<DeleteIssueResponseDTO>> Delete(Guid Id)
    {
        var command = new DeleteIssueCommand(Id);
        var result = await _mediator.Send(command);
        return Ok(result);
    }
}

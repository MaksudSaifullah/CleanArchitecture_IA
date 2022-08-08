using Internal.Audit.Application.Features.WorkPapers.Commands.AddWorkPaper;
using Internal.Audit.Application.Features.WorkPapers.Commands.DeleteWorkPaper;
using Internal.Audit.Application.Features.WorkPapers.Commands.UpdateWorkPaper;
using Internal.Audit.Application.Features.WorkPapers.Queries.GetWorkPaperById;
using Internal.Audit.Application.Features.WorkPapers.Queries.GetWorkPaperList;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Internal.Audit.Api.Controllers;

[Route("api/v{version:apiVersion}/workpaper")]
[ApiController]
public class WorkPaperController : ControllerBase
{
    private readonly IMediator _mediator;
    public WorkPaperController(IMediator madiator)
    {
        _mediator = madiator ?? throw new ArgumentNullException(nameof(madiator));
    }

    [HttpPost("paginated")]
    public async Task<ActionResult<WorkPaperListPagingDTO>> GetList(GetWorkPaperListQuery getWorkPaperListQuery)
    {
        var workPapers = await _mediator.Send(getWorkPaperListQuery);
        return Ok(workPapers);

    }

    [HttpGet("{Id}")]
    public async Task<ActionResult<WorkPaperByIdDTO>> GetById(Guid Id)
    {
        var query = new GetWorkPaperQuery(Id);
        var workPapers = await _mediator.Send(query);
        return Ok(workPapers);

    }

    [HttpPost]
    public async Task<ActionResult<AddWorkPaperResponseDTO>> Add(AddWorkPaperCommand command)
    {
        var result = await _mediator.Send(command);
        return Ok(result);
    }

    [HttpPut]
    public async Task<ActionResult<UpdateWorkPaperResponseDTO>> Update(UpdateWorkPaperCommand command)
    {
        var result = await _mediator.Send(command);
        return Ok(result);
    }

    [HttpDelete("{Id}")]
    public async Task<ActionResult<DeleteWorkPaperResponseDTO>> Delete(Guid Id)
    {
        var command = new DeleteWorkPaperCommand(Id);
        var result = await _mediator.Send(command);
        return Ok(result);
    }
}
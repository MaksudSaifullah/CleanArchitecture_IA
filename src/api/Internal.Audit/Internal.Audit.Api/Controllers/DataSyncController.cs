using Internal.Audit.Application.Features.AmbsDataSyncs.Command.AddAmbsDataSyncCommand;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Internal.Audit.Api.Controllers;

[Route("api/v{version:apiVersion}/DataSync")]
[ApiController]
public class DataSyncController : ControllerBase
{
    private readonly IMediator _mediator;
    public DataSyncController(IMediator madiator)
    {
        _mediator = madiator ?? throw new ArgumentNullException(nameof(madiator));
    }


    [HttpPost]
    public async Task<ActionResult<AddAmbsDataSyncCommandDTO>> GetList(AddAmbsDataSyncCommand command)
    {
        var result = await _mediator.Send(command);
        return Ok(result);


    }
}

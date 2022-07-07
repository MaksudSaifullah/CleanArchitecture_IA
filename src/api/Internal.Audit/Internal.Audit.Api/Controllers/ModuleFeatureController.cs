using Internal.Audit.Application.Features.ModuleFeature.Quiries.GetAllModuleList;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Internal.Audit.Api.Controllers;

[Route("api/v{version:apiVersion}/ModuleFeature")]
[ApiController]
public class ModuleFeatureController : ControllerBase
{
    private readonly IMediator _mediator;
    public ModuleFeatureController(IMediator madiator)
    {
        _mediator = madiator ?? throw new ArgumentNullException(nameof(madiator));
    }
    [HttpGet]
    public async Task<ActionResult<GetAllModuleListResponseDTO>> Get()
    {
        var query = new GetAllModuleListQuery();
        var result = await _mediator.Send(query);
        return Ok(result);
    }
}

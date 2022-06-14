using Internal.Audit.Application.Features.Module.Queries.GetModuleList;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Internal.Audit.Api.Controllers
{
    [Route("api/v{version:apiVersion}/module")]
    [ApiController]
    public class ModuleController : ControllerBase
    {
        private readonly IMediator _mediator;
        public ModuleController(IMediator madiator)
        {
            _mediator = madiator ?? throw new ArgumentNullException(nameof(madiator));
        }

        [HttpGet("all")]
        public async Task<ActionResult<IEnumerable<GetModuleListResponseDTO>>> GetList()
        {
            var query = new GetModuleListQuery();
            var users = await _mediator.Send(query);
            return Ok(users);

        }

       
    }
}


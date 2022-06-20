using Internal.Audit.Application.Features.Module.Queries.GetModuleList;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Internal.Audit.Api.Controllers
{
    [Route("api/v{version:apiVersion}/module")]
    [ApiController]
    public class AuditModuleController : ControllerBase
    {
        private readonly IMediator _mediator;
        public AuditModuleController(IMediator madiator)
        {
            _mediator = madiator ?? throw new ArgumentNullException(nameof(madiator));
        }

        [HttpGet("all")]
        public async Task<ActionResult<IEnumerable<GetActionModuleListResponseDTO>>> GetList()
        {
            var query = new GetActionModuleListQuery();
            var users = await _mediator.Send(query);
            return Ok(users);

        }

       
    }
}


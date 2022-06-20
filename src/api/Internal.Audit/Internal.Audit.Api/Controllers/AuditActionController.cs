using Internal.Audit.Application.Features.Action.Queries.GetActionList;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Internal.Audit.Api.Controllers
{
    [Route("api/v{version:apiVersion}/action")]
    [ApiController]
    public class AuditActionController : ControllerBase
    {
        private readonly IMediator _mediator;
        public AuditActionController(IMediator madiator)
        {
            _mediator = madiator ?? throw new ArgumentNullException(nameof(madiator));
        }

        [HttpGet("all")]
        public async Task<ActionResult<IEnumerable<GetAuditActionListResponseDTO>>> GetList()
        {
            var query = new GetAuditActionListQuery();
            var users = await _mediator.Send(query);
            return Ok(users);

        }


    }
}
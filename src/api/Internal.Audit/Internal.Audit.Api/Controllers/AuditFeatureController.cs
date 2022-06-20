using Internal.Audit.Application.Features.Feature.Queries.GetFeatureList;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Internal.Audit.Api.Controllers
{
    [Route("api/v{version:apiVersion}/feature")]
    [ApiController]
    public class AuditFeatureController : ControllerBase
    {
        private readonly IMediator _mediator;
        public AuditFeatureController(IMediator madiator)
        {
            _mediator = madiator ?? throw new ArgumentNullException(nameof(madiator));
        }

        [HttpGet("all")]
        public async Task<ActionResult<IEnumerable<GetAuditFeatureListResponseDTO>>> GetList()
        {
            var query = new GetAuditFeatureListQuery();
            var users = await _mediator.Send(query);
            return Ok(users);

        }


    }
}
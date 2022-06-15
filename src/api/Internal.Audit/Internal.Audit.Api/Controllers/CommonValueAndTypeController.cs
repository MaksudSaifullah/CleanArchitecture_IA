using Microsoft.AspNetCore.Mvc;

namespace Internal.Audit.Api.Controllers
{
    [Route("api/v{version:apiVersion}/accessPrivilege")]
    [ApiController]
    public class CommonValueAndTypeController : ControllerBase
    {
        private readonly IMediator _mediator;
        public CommonValueAndTypeController(IMediator madiator)
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
    }
}

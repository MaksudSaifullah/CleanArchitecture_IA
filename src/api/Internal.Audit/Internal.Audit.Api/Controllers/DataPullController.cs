//using Internal.Audit.MQ.Service.Services;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Internal.Audit.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DataPullController : ControllerBase
    {
        private readonly IMediator _mediator;
        public DataPullController(IMediator madiator)
        {
            _mediator = madiator ?? throw new ArgumentNullException(nameof(madiator));
        }

        [HttpGet("all")]
        public async Task<ActionResult> GetList()
        {
           
            return Ok("");

        }
    }
}

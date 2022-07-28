//using Internal.Audit.MQ.Service.Services;
using Internal.Audit.Application.Features.DataPull.Commands.AddDataPullCommand;
using Internal.Audit.Application.Features.DataRequestQueue.Command.AddDataRequestQueueCommand;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Internal.Audit.Api.Controllers
{
    [Route("api/v{version:apiVersion}/DataPull")]
   
    [ApiController]
    public class DataPullController : ControllerBase
    {
        private readonly IMediator _mediator;
        public DataPullController(IMediator madiator)
        {
            _mediator = madiator ?? throw new ArgumentNullException(nameof(madiator));
        }

        [HttpPost]
        
        public async Task<ActionResult<AddDataRequestCommandDTO>> GetList(AddDatarequestCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
         

        }
    }
}

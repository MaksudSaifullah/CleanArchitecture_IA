//using Internal.Audit.MQ.Service.Services;
using Internal.Audit.Application.Features.DataPull.Commands.AddDataPullCommand;
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
        
        public async Task<ActionResult<AddDataPullCommandDTO>> GetList(AddDataCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
         

        }
    }
}

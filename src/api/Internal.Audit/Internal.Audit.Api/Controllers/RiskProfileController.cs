using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Internal.Audit.Api.Controllers
{
    [Route("api/v{version:apiVersion}/riskprofile")]
    [ApiController]
    public class RiskProfileController : ControllerBase
    {
        private readonly IMediator _mediator;
        public RiskProfileController(IMediator madiator)
        {
            _mediator = madiator ?? throw new ArgumentNullException(nameof(madiator));
        }

        [HttpGet("all")]
        public async Task<ActionResult<IEnumerable<RiskProfileDTO>>> GetList()
        {
            var query = new GetRiskProfileListQuery();
            var users = await _mediator.Send(query);
            return Ok(users);

        }

        [HttpGet("{Id}")]
        public async Task<ActionResult<RiskProfileByIdDTO>> GetById(Guid Id)
        {
            var query = new GetRiskProfileQuery(Id);
            var users = await _mediator.Send(query);
            return Ok(users);

        }

        [HttpPost]
        public async Task<ActionResult<AddRiskProfileResponseDTO>> Add(AddRiskProfileCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpPut]
        public async Task<ActionResult<UpdateRiskProfileResponseDTO>> Update(UpdateRiskProfileCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpDelete("{Id}")]
        public async Task<ActionResult<DeleteRiskProfileResponseDTO>> Delete(Guid Id)
        {
            var command = new DeleteRiskProfileCommand(Id);
            var result = await _mediator.Send(command);
            return Ok(result);
        }
    }
}

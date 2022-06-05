using Internal.Audit.Application.Features.UserCountries.Commands.AddUserCountry;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Internal.Audit.Api.Controllers
{
    [Route("api/v{version:apiVersion}/userCountry")]
    [ApiController]
    public class UserCountryController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UserCountryController(IMediator madiator)
        {
            _mediator = madiator ?? throw new ArgumentNullException(nameof(madiator));
        }

        [HttpPost()]
        public async Task<ActionResult<AddUserCountryResponseDTO>> Add(AddUserCountryCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);

        }
    }
}

using Internal.Audit.Application.Features.Countries.Queries.GetCountryList;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Internal.Audit.Api.Controllers
{
    [Route("api/v{version:apiVersion}/country")]
    [ApiController]
    public class CountryController : ControllerBase
    {
        private readonly IMediator _mediator;
        public CountryController(IMediator madiator)
        {
            _mediator = madiator ?? throw new ArgumentNullException(nameof(madiator));
        }

        [HttpGet("all")]
        public async Task<ActionResult<IEnumerable<CountryDTO>>> GetList()
        {
            var query = new GetCountryListQuery();
            var users = await _mediator.Send(query);
            return Ok(users);

        }

        //[HttpPost()]
        //public async Task<ActionResult<AddUserResponseDTO>> Add(AddUserCommand command)
        //{
        //    var result = await _mediator.Send(command);
        //    return Ok(result);

        //}

        //[HttpPut()]
        //public async Task<ActionResult<UpdateUserResponseDTO>> Update(UpdateUserCommand command)
        //{
        //    var result = await _mediator.Send(command);
        //    return Ok(result);

        //}

        //[HttpDelete("{id}")]
        //public async Task<ActionResult<UpdateUserResponseDTO>> Delete(Guid id)
        //{
        //    var command = new DeleteUserCommand(id);
        //    var result = await _mediator.Send(command);
        //    return Ok(result);

        //}
    }
}

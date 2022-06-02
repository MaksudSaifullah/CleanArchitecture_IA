using Internal.Audit.Application.Features.Designation.Commands.AddDesignation;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Internal.Audit.Api.Controllers
{
    [Route("api/v{version:apiVersion}/designation")]
    [ApiController]
    public class DesignationController : ControllerBase
    {
        private readonly IMediator _mediator;
        public DesignationController(IMediator madiator)
        {
            _mediator = madiator ?? throw new ArgumentNullException(nameof(madiator));
        }

        //[HttpGet("all")]
        //public async Task<ActionResult<IEnumerable<CountryDTO>>> GetList()
        //{
        //    var query = new GetCountryListQuery();
        //    var users = await _mediator.Send(query);
        //    return Ok(users);

        //}

        //[HttpGet("{Id}")]
        //public async Task<ActionResult<CountryByIdDTO>> GetById(Guid Id)
        //{
        //    var query = new GetCountryQuery(Id);
        //    var users = await _mediator.Send(query);
        //    return Ok(users);

        //}

        [HttpPost]
        public async Task<ActionResult<AddDesignationResponseDTO>> Add(AddDesignationCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        //[HttpPut]
        //public async Task<ActionResult<UpdateCountryResponseDTO>> Update(UpdateCountryCommand command)
        //{
        //    var result = await _mediator.Send(command);
        //    return Ok(result);
        //}

        //[HttpDelete("{Id}")]
        //public async Task<ActionResult<DeleteCountryResponseDTO>> Delete(Guid Id)
        //{
        //    var command = new DeleteCountryCommand(Id);
        //    var result = await _mediator.Send(command);
        //    return Ok(result);
        //}
    }
}

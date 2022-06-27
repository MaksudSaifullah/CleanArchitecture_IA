
using Internal.Audit.Application.Features.Countries.Commands.AddCountry;
using Internal.Audit.Application.Features.Countries.Commands.DeleteCountry;
using Internal.Audit.Application.Features.Countries.Commands.UpdateCountry;
using Internal.Audit.Application.Features.Countries.Queries.GetCountryById;
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

        [HttpGet()]
        public async Task<ActionResult<CountryListPagingDTO>> GetList(int pageSize, int pageNumber)
        {
            var query = new GetCountryListQuery(pageSize, pageNumber);
            var countries = await _mediator.Send(query);
            return Ok(countries);

        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CountryByIdDTO>> GetById(Guid Id)
        {
            var query = new GetCountryQuery(Id);
            var countries = await _mediator.Send(query);
            return Ok(countries);

        }

        [HttpPost]
        public async Task<ActionResult<AddCountryResponseDTO>> Add(AddCountryCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpPut]
        public async Task<ActionResult<UpdateCountryResponseDTO>> Update(UpdateCountryCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<DeleteCountryResponseDTO>> Delete(Guid Id)
        {
            var command = new DeleteCountryCommand(Id);
            var result = await _mediator.Send(command);
            return Ok(result);
        }

    }
}

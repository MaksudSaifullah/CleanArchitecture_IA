using Internal.Audit.Application.Features.WeightScoreConfigurations.Queries.WeightScoreByCountryId;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Internal.Audit.Api.Controllers
{
    [Route("api/v{version:apiVersion}/weightscoreconfiguration")]
    [ApiController]
    public class WeightScoreConfigurationController : Controller
    {
       
        private readonly IMediator _mediator;
        public WeightScoreConfigurationController(IMediator madiator)
        {
            _mediator = madiator ?? throw new ArgumentNullException(nameof(madiator));
        }

       
        [HttpGet("{CountryId}")]
        public async Task<ActionResult<WeightScoreByCountryIdDTO>> GetById(Guid CountryId)
        {
            var query = new GetWeightScoreQuery(CountryId);
            var designation = await _mediator.Send(query);
            return Ok(designation);

        }
    }
}

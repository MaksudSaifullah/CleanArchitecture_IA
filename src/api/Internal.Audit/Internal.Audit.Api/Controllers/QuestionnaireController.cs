using Internal.Audit.Application.Features.Questionnnaires.Queries.GetQuestionnnaireList;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Internal.Audit.Api.Controllers
{
    [Microsoft.AspNetCore.Components.Route("api/v{version:apiVersion}/country")]
    [ApiController]
    public class QuestionnaireController : ControllerBase
    {
        private readonly IMediator _mediator;
        public QuestionnaireController(IMediator madiator)
        {
            _mediator = madiator ?? throw new ArgumentNullException(nameof(madiator));
        }

        [HttpPost("paginated")]
        public async Task<ActionResult<GetQuestionnaireListPagingDTO>> GetList(GetQuestionnaireListQuery getQuestionnaireListQuery)
        {            
            var questionnaires = await _mediator.Send(getQuestionnaireListQuery);
            return Ok(questionnaires);

        }

        //[HttpGet("{id}")]
        //public async Task<ActionResult<CountryByIdDTO>> GetById(Guid Id)
        //{
        //    var query = new GetCountryQuery(Id);
        //    var countries = await _mediator.Send(query);
        //    return Ok(countries);

        //}

        //[HttpPost]
        //public async Task<ActionResult<AddCountryResponseDTO>> Add(AddCountryCommand command)
        //{
        //    var result = await _mediator.Send(command);
        //    return Ok(result);
        //}

        //[HttpPut]
        //public async Task<ActionResult<UpdateCountryResponseDTO>> Update(UpdateCountryCommand command)
        //{
        //    var result = await _mediator.Send(command);
        //    return Ok(result);
        //}

        //[HttpDelete("{id}")]
        //public async Task<ActionResult<DeleteCountryResponseDTO>> Delete(Guid Id)
        //{
        //    var command = new DeleteCountryCommand(Id);
        //    var result = await _mediator.Send(command);
        //    return Ok(result);
        //}

    }
}


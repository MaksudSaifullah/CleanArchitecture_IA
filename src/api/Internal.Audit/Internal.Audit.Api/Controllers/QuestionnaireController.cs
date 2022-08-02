using Internal.Audit.Application.Features.Questionnnaires.Commands.AddQuestionnaire;
using Internal.Audit.Application.Features.Questionnnaires.Commands.DeleteQuestionnaire;
using Internal.Audit.Application.Features.Questionnnaires.Commands.UpdateQuestionnaire;
using Internal.Audit.Application.Features.Questionnnaires.Queries.GetQuestionnaireByFilter;
using Internal.Audit.Application.Features.Questionnnaires.Queries.GetQuestionnaireById;
using Internal.Audit.Application.Features.Questionnnaires.Queries.GetQuestionnnaireList;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Internal.Audit.Api.Controllers
{
    [Route("api/v{version:apiVersion}/questionnaire")]
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

        [HttpPost("filter")]
        public async Task<ActionResult<IEnumerable<GetQuestionnaireByFilterResponseDTO>>> GetByFilter(GetQuestionnaireFilterDTO Filter)
        {
            var query = new GetQuestionnaireByFilterQuery(Filter);
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [HttpGet("id")]
        public async Task<ActionResult<GetQuestionnaireByIdDTO>> GetById(Guid Id)
        {
            var query = new GetQuestionnaireByIdQuery(Id);
            var questionnaire = await _mediator.Send(query);
            return Ok(questionnaire);
        }

        [HttpPost]
        public async Task<ActionResult<AddQuestionnaireResponseDTO>> Add(AddQuestionnaireCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpPut]
        public async Task<ActionResult<UpdateQuestionnaireResponseDTO>> Update(UpdateQuestionnaireCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpDelete("id")]
        public async Task<ActionResult<DeleteQuestionnaireResponseDTO>> Delete(Guid Id)
        {
            var command = new DeleteQuestionnaireCommand(Id);
            var result = await _mediator.Send(command);
            return Ok(result);
        }
    }
}
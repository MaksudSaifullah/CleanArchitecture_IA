
using Internal.Audit.Application.Features.TestSteps.Queries.GetTestStepById;
using Internal.Audit.Application.Features.TestSteps.Queries.GetTestStepList;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Internal.Audit.Api.Controllers
{
    [Route("api/v{version:apiVersion}/test-step")]
    [ApiController]
    public class TestStepController : ControllerBase
    {
        private readonly IMediator _mediator;
        public TestStepController(IMediator madiator)
        {
            _mediator = madiator ?? throw new ArgumentNullException(nameof(madiator));
        }

        [HttpPost("paginated")]
        public async Task<ActionResult<GetTestStepListPagingDTO>> GetList(GetTestStepListQuery query)
        {
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [HttpGet("id")]
        public async Task<ActionResult<GetTestStepByIdDTO>> GetById(Guid Id)
        {
            var query = new GetTestStepByIdQuery(Id);
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        //[HttpPost]
        //public async Task<ActionResult<AddQuestionnaireResponseDTO>> Add(AddQuestionnaireCommand command)
        //{
        //    var result = await _mediator.Send(command);
        //    return Ok(result);
        //}

        //[HttpPut]
        //public async Task<ActionResult<UpdateQuestionnaireResponseDTO>> Update(UpdateQuestionnaireCommand command)
        //{
        //    var result = await _mediator.Send(command);
        //    return Ok(result);
        //}

        //[HttpDelete("id")]
        //public async Task<ActionResult<DeleteQuestionnaireResponseDTO>> Delete(Guid Id)
        //{
        //    var command = new DeleteQuestionnaireCommand(Id);
        //    var result = await _mediator.Send(command);
        //    return Ok(result);
        //}
    }
}
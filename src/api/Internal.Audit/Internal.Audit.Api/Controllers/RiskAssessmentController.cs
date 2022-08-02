using Internal.Audit.Application.Features.RiskAssessments.Commands.AddRiskAssessment;
using Internal.Audit.Application.Features.RiskAssessments.Commands.DeleteRiskAssessment;
using Internal.Audit.Application.Features.RiskAssessments.Commands.UpdateRiskAssessment;
using Internal.Audit.Application.Features.RiskAssessments.Queries.GetRiskAssessmentById;
using Internal.Audit.Application.Features.RiskAssessments.Queries.GetRiskAssessmentList;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Internal.Audit.Api.Controllers
{
    [Route("api/v{version:apiVersion}/riskassessment")]
    [ApiController]
    public class RiskAssessmentController : ControllerBase
    {
        private readonly IMediator _mediator;
        public RiskAssessmentController(IMediator madiator)
        {
            _mediator = madiator ?? throw new ArgumentNullException(nameof(madiator));
        }

        [HttpPost("paginated")]
        public async Task<ActionResult<RiskAssessmentListPagingDTO>> GetList(GetRiskAssessmentListQuery getRiskAssessmentListQuery)
        {
            var riskAssessments = await _mediator.Send(getRiskAssessmentListQuery);
            return Ok(riskAssessments);

        }

        [HttpGet("{Id}")]
        public async Task<ActionResult<RiskAssessmentByIdDTO>> GetById(Guid Id)
        {
            var query = new GetRiskAssessmentQuery(Id);
            var riskAssessments = await _mediator.Send(query);
            return Ok(riskAssessments);

        }

        [HttpGet("CountryId")]
        public async Task<ActionResult<RiskAssessmentByIdDTO>> GetByCountryId(Guid CountryId)
        {
            var query = new GetRiskAssessmentByCountryQuery(CountryId);
            var riskAssessments = await _mediator.Send(query);
            return Ok(riskAssessments);

        }

        [HttpPost]
        public async Task<ActionResult<AddRiskAssessmentResponseDTO>> Add(AddRiskAssessmentCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpPut]
        public async Task<ActionResult<UpdateRiskAssessmentResponseDTO>> Update(UpdateRiskAssessmentCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpDelete("{Id}")]
        public async Task<ActionResult<DeleteRiskAssessmentResponseDTO>> Delete(Guid Id)
        {
            var command = new DeleteRiskAssessmentCommand(Id);
            var result = await _mediator.Send(command);
            return Ok(result);
        }
    }
}

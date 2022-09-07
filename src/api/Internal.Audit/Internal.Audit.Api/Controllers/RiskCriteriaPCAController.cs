using Internal.Audit.Application.Features.RiskCriteriasPCA.Queries.GetRiskCriteriaById;
using Internal.Audit.Application.Features.RiskCriteriasPCA.Queries.GetRiskCriteriaList;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Internal.Audit.Application.Features.RiskCriteriasPCA.Commands.AddRiskCriteria;
using Internal.Audit.Application.Features.RiskCriteriasPCA.Commands.UpdateRiskCriteria;
using Internal.Audit.Application.Features.RiskCriteriasPCA.Commands.DeleteRiskCriteria;

namespace Internal.Audit.Api.Controllers
{
    [Route("api/v{version:apiVersion}/riskcriteriapca")]
    [ApiController]
    public class RiskCriteriaPCAController : ControllerBase
    {
        private readonly IMediator _mediator;
        public RiskCriteriaPCAController(IMediator madiator)
        {
            _mediator = madiator ?? throw new ArgumentNullException(nameof(madiator));
        }

        [HttpPost("paginated")]
        public async Task<ActionResult<RiskCriteriaPCAListPagingDTO>> GetList(GetRiskCriteriaPCAListQuery getRiskCriteriaListQuery)
        {
            var riskCriteria = await _mediator.Send(getRiskCriteriaListQuery);
            return Ok(riskCriteria);

        }

        [HttpGet("{Id}")]
        public async Task<ActionResult<RiskCriteriaPCAByIdDTO>> GetById(Guid Id)
        {
            var query = new GetRiskCriteriaPCAQuery(Id);
            var riskCriterias = await _mediator.Send(query);
            return Ok(riskCriterias);

        }

        [HttpPost]
        public async Task<ActionResult<AddRiskCriteriaPCAResponseDTO>> Add(AddRiskCriteriaPCACommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpPut]
        public async Task<ActionResult<UpdateRiskCriteriaPCAResponseDTO>> Update(UpdateRiskCriteriaPCACommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpDelete("{Id}")]
        public async Task<ActionResult<DeleteRiskCriteriaPCAResponseDTO>> Delete(Guid Id)
        {
            var command = new DeleteRiskCriteriaPCACommand(Id);
            var result = await _mediator.Send(command);
            return Ok(result);
        }
    }
}

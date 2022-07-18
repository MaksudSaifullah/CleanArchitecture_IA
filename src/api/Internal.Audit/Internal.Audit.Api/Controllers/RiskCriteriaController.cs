using Internal.Audit.Application.Features.RiskCriterias.Queries.GetRiskCriteriaById;
using Internal.Audit.Application.Features.RiskCriterias.Queries.GetRiskCriteriaList;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Internal.Audit.Application.Features.RiskCriterias.Commands.AddRiskCriteria;
using Internal.Audit.Application.Features.RiskCriterias.Commands.UpdateRiskCriteria;
using Internal.Audit.Application.Features.RiskCriterias.Commands.DeleteRiskCriteria;

namespace Internal.Audit.Api.Controllers
{
    [Route("api/v{version:apiVersion}/riskcriteria")]
    [ApiController]
    public class RiskCriteriaController : ControllerBase
    {
        private readonly IMediator _mediator;
        public RiskCriteriaController(IMediator madiator)
        {
            _mediator = madiator ?? throw new ArgumentNullException(nameof(madiator));
        }

        [HttpPost("paginated")]
        public async Task<ActionResult<RiskCriteriaListPagingDTO>> GetList(GetRiskCriteriaListQuery getRiskCriteriaListQuery)
        {
            var riskCriteria = await _mediator.Send(getRiskCriteriaListQuery);
            return Ok(riskCriteria);

        }

        [HttpGet("{Id}")]
        public async Task<ActionResult<RiskCriteriaByIdDTO>> GetById(Guid Id)
        {
            var query = new GetRiskCriteriaQuery(Id);
            var riskCriterias = await _mediator.Send(query);
            return Ok(riskCriterias);

        }

        [HttpPost]
        public async Task<ActionResult<AddRiskCriteriaResponseDTO>> Add(AddRiskCriteriaCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpPut]
        public async Task<ActionResult<UpdateRiskCriteriaResponseDTO>> Update(UpdateRiskCriteriaCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpDelete("{Id}")]
        public async Task<ActionResult<DeleteRiskCriteriaResponseDTO>> Delete(Guid Id)
        {
            var command = new DeleteRiskCriteriaCommand(Id);
            var result = await _mediator.Send(command);
            return Ok(result);
        }
    }
}

using Internal.Audit.Application.Features.AuditPlans.Commands.AddAuditPlan;
using Internal.Audit.Application.Features.AuditPlans.Commands.DeleteAuditPlan;
using Internal.Audit.Application.Features.AuditPlans.Commands.UpdateAuditPlan;
using Internal.Audit.Application.Features.AuditPlans.Queries.GetAuditPlanById;
using Internal.Audit.Application.Features.AuditPlans.Queries.GetAuditPlanList;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Internal.Audit.Api.Controllers
{
    [Route("api/v{version:apiVersion}/auditplan")]
    [ApiController]
    public class AuditPlanController : ControllerBase
    {
        private readonly IMediator _mediator;
        public AuditPlanController(IMediator madiator)
        {
            _mediator = madiator ?? throw new ArgumentNullException(nameof(madiator));
        }

        [HttpPost("paginated")]
        public async Task<ActionResult<AuditPlanListPagingDTO>> GetList(GetAuditPlanListQuery getAuditPlanListQuery)
        {
            var auditPlans = await _mediator.Send(getAuditPlanListQuery);
            return Ok(auditPlans);

        }

        [HttpGet("{Id}")]
        public async Task<ActionResult<AuditPlanByIdDTO>> GetById(Guid Id)
        {
            var query = new GetAuditPlanQuery(Id);
            var auditPlans = await _mediator.Send(query);
            return Ok(auditPlans);

        }

        [HttpPost]
        public async Task<ActionResult<AddAuditPlanResponseDTO>> Add(AddAuditPlanCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpPut]
        public async Task<ActionResult<UpdateAuditPlanResponseDTO>> Update(UpdateAuditPlanCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpDelete("{Id}")]
        public async Task<ActionResult<DeleteAuditPlanResponseDTO>> Delete(Guid Id)
        {
            var command = new DeleteAuditPlanCommand(Id);
            var result = await _mediator.Send(command);
            return Ok(result);
        }
    }
}

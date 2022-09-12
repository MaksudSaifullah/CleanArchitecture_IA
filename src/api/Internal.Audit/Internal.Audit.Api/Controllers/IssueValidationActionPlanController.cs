using Internal.Audit.Application.Features.IssueValidationActionPlans.Commands.DeleteActionPlans;
using Internal.Audit.Application.Features.IssueValidationActionPlans.Commands.IssueActionPlans;
using Internal.Audit.Application.Features.IssueValidationActionPlans.Commands.UpdateIssueActionPlans;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Internal.Audit.Api.Controllers
{
    [Route("api/v{version:apiVersion}/issueValidationActionPlan")]
    [ApiController]
    public class IssueValidationActionPlanController : ControllerBase
    {
        private readonly IMediator _mediator;
        public IssueValidationActionPlanController(IMediator madiator)
        {
            _mediator = madiator ?? throw new ArgumentNullException(nameof(madiator));
        }
        [HttpPost]
        public async Task<ActionResult<IssueActionPlanCommandResponseDTO>> Add(IssueActionPlanCommand     command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpPut]
        public async Task<ActionResult<UpdateIssueActionPlanResponseDTO>> Update(UpdateIssueActionPlanCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpDelete]
        public async Task<ActionResult<DeleteActionPlanCommandResponseDTO>> Delete(Guid Id)
        {
            var command = new DeleteActionPlanCommand(Id);
            var result = await _mediator.Send(command);
            return Ok(result);
        }
    }
}

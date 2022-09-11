using Internal.Audit.Application.Features.IssueValidationActionPlans.Commands.IssueActionPlans;
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
    }
}

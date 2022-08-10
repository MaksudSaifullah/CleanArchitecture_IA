using Internal.Audit.Application.Features.RiskAssesmentDataManagementLogs.Commands.AddRiskAssesmentDataManagementLog;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Internal.Audit.Api.Controllers
{
    [Route("api/v{version:apiVersion}/RiskAssesmentDataManagement")]
    [ApiController]
    public class RiskAssesmentDataManagementController : ControllerBase
    {
        private readonly IMediator _mediator;
        public RiskAssesmentDataManagementController(IMediator madiator)
        {
            _mediator = madiator ?? throw new ArgumentNullException(nameof(madiator));
        }

        [HttpPost]
        public async Task<ActionResult<AddRiskAssesmentDataManagementLogResponseDTO>> Add(AddRiskAssesmentDataManagementLogCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

    }
}

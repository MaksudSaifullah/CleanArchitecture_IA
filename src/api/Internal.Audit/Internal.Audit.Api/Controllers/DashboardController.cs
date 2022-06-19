using Internal.Audit.Application.Features.Dashboards.Commands.AddDashboard;
using Internal.Audit.Application.Features.Dashboards.Commands.DeleteDashboard;
using Internal.Audit.Application.Features.Dashboards.Commands.UpdateDashboard;
using Internal.Audit.Application.Features.Dashboards.Queries.GetDashboardById;
using Internal.Audit.Application.Features.Dashboards.Queries.GetDashboardList;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Internal.Audit.Api.Controllers
{
    [Route("api/v{version:apiVersion}/dashboard")]
    [ApiController]
    public class DashboardController : ControllerBase
    {
        private readonly IMediator _mediator;
        public DashboardController(IMediator madiator)
        {
            _mediator = madiator ?? throw new ArgumentNullException(nameof(madiator));
        }

        [HttpGet("all")]
        public async Task<ActionResult<IEnumerable<DashboardDTO>>> GetList()
        {
            var query = new GetDashboardListQuery();
            var dashboards = await _mediator.Send(query);
            return Ok(dashboards);

        }

        [HttpGet("{Id}")]
        public async Task<ActionResult<DashboardByIdDTO>> GetById(Guid Id)
        {
            var query = new GetDashboardQuery(Id);
            var dashboards = await _mediator.Send(query);
            return Ok(dashboards);

        }

        [HttpPost]
        public async Task<ActionResult<AddDashboardResponseDTO>> Add(AddDashboardCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpPut]
        public async Task<ActionResult<UpdateDashboardResponseDTO>> Update(UpdateDashboardCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpDelete("{Id}")]
        public async Task<ActionResult<DeleteDashboardResponseDTO>> Delete(Guid Id)
        {
            var command = new DeleteDashboardCommand(Id);
            var result = await _mediator.Send(command);
            return Ok(result);
        }

    }
}

using Internal.Audit.Application.Features.Roles.Commands.AddRole;
using Internal.Audit.Application.Features.Roles.Commands.DeleteRole;
using Internal.Audit.Application.Features.Roles.Commands.UpdateRole;
using Internal.Audit.Application.Features.Roles.Queries.GetRoleById;
using Internal.Audit.Application.Features.Roles.Queries.GetRolesList;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Internal.Audit.Api.Controllers
{
    [Route("api/v{version:apiVersion}/role")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        private readonly IMediator _mediator;
        public RoleController(IMediator madiator)
        {
            _mediator = madiator ?? throw new ArgumentNullException(nameof(madiator));
        }

        [HttpGet("all")]
        public async Task<ActionResult<IEnumerable<RoleDTO>>> GetList()
        {
            var query = new GetRoleListQuery();
            var users = await _mediator.Send(query);
            return Ok(users);

        }

        [HttpGet("{Id}")]
        public async Task<ActionResult<RoleByIdDTO>> GetById(Guid Id)
        {
            var query = new GetRoleQuery(Id);
            var users = await _mediator.Send(query);
            return Ok(users);

        }

        [HttpPost]
        public async Task<ActionResult<AddRoleResponseDTO>> Add(AddRoleCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpPut]
        public async Task<ActionResult<UpdateRoleResponseDTO>> Update(UpdateRoleCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpDelete("{Id}")]
        public async Task<ActionResult<DeleteRoleResponseDTO>> Delete(Guid Id)
        {
            var command = new DeleteRoleCommand(Id);
            var result = await _mediator.Send(command);
            return Ok(result);
        }

    }
}


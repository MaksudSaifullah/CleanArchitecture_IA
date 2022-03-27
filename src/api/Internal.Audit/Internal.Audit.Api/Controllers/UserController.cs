using Internal.Audit.Application.Features.Users.Commands.AddUser;
using Internal.Audit.Application.Features.Users.Commands.DeleteUser;
using Internal.Audit.Application.Features.Users.Commands.UpdateUser;
using Internal.Audit.Application.Features.Users.Queries.GetUserList;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Internal.Audit.Api.Controllers
{
    [Route("api/v{version:apiVersion}/user")]
    [ApiController]
    [Authorize]
    public class UserController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UserController(IMediator madiator)
        {
            _mediator = madiator ?? throw new ArgumentNullException(nameof(madiator));
        }

        [HttpGet("all/{activeOnly}")]
        public async Task<ActionResult<IEnumerable<UserDTO>>> Get(bool activeOnly)
        {
            var query = new GetUserListQuery(activeOnly);
            var users = await _mediator.Send(query);
            return Ok(users);

        }

        [HttpPost()]
        public async Task<ActionResult<AddUserResponseDTO>> Add(AddUserCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);

        }

        [HttpPut()]
        public async Task<ActionResult<UpdateUserResponseDTO>> Update(UpdateUserCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);

        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<UpdateUserResponseDTO>> Delete(long id)
        {
            var command = new DeleteUserCommand(id);
            var result = await _mediator.Send(command);
            return Ok(result);

        }
    }
}

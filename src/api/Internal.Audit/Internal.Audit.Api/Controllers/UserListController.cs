using Internal.Audit.Application.Features.UserList.Commands.UpdateUser;
using Internal.Audit.Application.Features.UserList.Queries.GetUserList;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Internal.Audit.Api.Controllers
{
    [Route("api/v{version:apiVersion}/userlist")]
    [ApiController]
    public class UserListController : ControllerBase
    {
        private readonly IMediator _mediator;
        public UserListController(IMediator mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }
        [HttpPost("Paginated")]
        public async Task<ActionResult<UserListWithPagingInfoDTO>> GetList(GetUserListQuery getUserListQuery)
        {
            var userListWithPagingInfo = await _mediator.Send(getUserListQuery);
            return Ok(userListWithPagingInfo);
        }

        [HttpPut("UpdateUser")]
        public async Task<ActionResult<UpdateUserListResponseDTO>> Update(UpdateUserListCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpGet("{Id}")]
        public async Task<ActionResult<GetUserListResponseDTO>> Get(Guid Id)
        {
            var query = new GetUserQuery(Id);
            var users = await _mediator.Send(query);
            return Ok(users);

        }
       
        [HttpPut("BlockUser")]
        public async Task<ActionResult<UpdateUserResponseDTO>> BlockUser(UpdateUserCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }
    }
}

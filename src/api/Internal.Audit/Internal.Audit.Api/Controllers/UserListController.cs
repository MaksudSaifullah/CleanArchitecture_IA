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
       // [HttpGet("all")]
       [HttpGet("{userName}/{employeeName}/{userRole}")]
        public async Task<ActionResult<IEnumerable<GetUserListResponseDTO>>> GetList(string userName,string employeeName,string userRole)
        {
            var query = new GetUserListQuery(userName,employeeName,userRole);
            var users = await _mediator.Send(query);
            return Ok(users);
        }

        [HttpPut()]
        public async Task<ActionResult<UpdateUserListResponseDTO>> Update(UpdateUserListCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        //[HttpGet("{Id}/")]
        //public async Task<ActionResult<GetUserListResponseDTO>> GetById(Guid Id)
        //{
        //    //var query = new GetCountryQuery(Id);
        //    //var users = await _mediator.Send(query);
        //    //return Ok(0);

        //}


    }
}

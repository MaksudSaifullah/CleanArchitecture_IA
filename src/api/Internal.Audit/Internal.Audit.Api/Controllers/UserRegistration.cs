using Internal.Audit.Application.Features.UserRegistration.Commands.AddUserRegistration;
using Internal.Audit.Application.Features.UserRegistration.Queries.GetAllUserList;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Internal.Audit.Api.Controllers
{
    [Route("api/v{version:apiVersion}/UserRegistration")]
    [ApiController]
    public class UserRegistration : ControllerBase
    {
        private readonly IMediator _mediator;
        public UserRegistration(IMediator madiator)
        {
            _mediator = madiator ?? throw new ArgumentNullException(nameof(madiator));
        }

        [HttpPost]
        public async Task<ActionResult<AddUserRegistrationResponseDTO>> Add(AddUserRegistrationCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpGet("{Id}")]
        public async Task<ActionResult<GetUserListResponseDTO>> Get(Guid Id)
        {
            var query = new GetUserListQuery(Id);
            var result = await _mediator.Send(query);
            return Ok(result);
        }
    }
}

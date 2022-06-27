//using Internal.Audit.Application.Features.Users.Queries.GetAuthUser;
using Internal.Audit.Application.Features.UserList.Queries.GetAuthUser;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Internal.Audit.Api.Controllers
{
    [Route("api/v{version:apiVersion}/authentication")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AuthenticationController(IMediator mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        [HttpPost]
        public async Task<ActionResult<AuthUserDTO>> Get(GetAuthUserQuery query)
        {
            var result = await _mediator.Send(query);
            return Ok(result);
        }
    }
}

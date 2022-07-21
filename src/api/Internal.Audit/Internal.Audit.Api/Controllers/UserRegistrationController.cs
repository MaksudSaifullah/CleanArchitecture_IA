using Internal.Audit.Application.Features.UserRegistration.Commands.AddUserRegistration;
using Internal.Audit.Application.Features.UserRegistration.Commands.ChangeUserPassword;
using Internal.Audit.Application.Features.UserRegistration.Commands.DeleteUserRegistration;
using Internal.Audit.Application.Features.UserRegistration.Commands.UpdateUserProfile;
using Internal.Audit.Application.Features.UserRegistration.Commands.UpdateUserRegistration;
using Internal.Audit.Application.Features.UserRegistration.Queries.GetAllUserList;
using Internal.Audit.Application.Features.UserRegistration.Queries.GetALlUserListById;
using Internal.Audit.Application.Features.UserRegistration.Queries.GetUserProfile;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Internal.Audit.Api.Controllers;

[Route("api/v{version:apiVersion}/UserRegistration")]
[ApiController]
public class UserRegistrationController : ControllerBase
{
    private readonly IMediator _mediator;
    public UserRegistrationController(IMediator madiator)
    {
        _mediator = madiator ?? throw new ArgumentNullException(nameof(madiator));
    }
    [Authorize]
    [HttpPost("ChangePassword")]
    public async Task<ActionResult<Tuple<bool, string>>> ChangePassword(ChangeUserPasswordCommand command) => Ok(await _mediator.Send(command));

    [HttpPost]
    public async Task<ActionResult<AddUserRegistrationResponseDTO>> Add(AddUserRegistrationCommand command)
    {
        var result = await _mediator.Send(command);
        return Ok(result);
    }

    [HttpGet]
    public async Task<ActionResult<GetUserListResponseDTO>> Get()
    {
        var query = new GetUserListQuery();
        var result = await _mediator.Send(query);
        return Ok(result);
    }

    [HttpGet("Id")]
    public async Task<ActionResult<GetUserListResponseDTO>> Get(Guid Id)
    {
        var query = new GetAllUserListByIdQuery(Id);
        var result = await _mediator.Send(query);
        return Ok(result);
    }

    [HttpPut]
    public async Task<ActionResult<UpdateUserRegistrationResponseDTO>> Update(UpdateUserRegistrationCommand command)
    {
        var result = await _mediator.Send(command);
        return Ok(result);
    }
    [HttpDelete]
    public async Task<ActionResult<DeleteUserRegistrationResponseDTO>> Delete(Guid userId)
    {
        var query = new DeleteUserRegistrationCommand(userId);
        var result = await _mediator.Send(query);
        return Ok(result);
    }
    [Authorize]
    [HttpGet("GetUserProfile")]
    public async Task<ActionResult> GetUserProfile()
    {
        return Ok(await _mediator.Send(new UserProfileQuery()));
    }
    [Authorize]
    [HttpPost("UpdateUserProfile")]
    public async Task<ActionResult> UpdateUserProfile(UpdateUserProfileCommand command)
    {
        return Ok(await _mediator.Send(command));
    }
}

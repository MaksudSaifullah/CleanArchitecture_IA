using Internal.Audit.Application.Features.ModulewiseRolePrivilege.Commands.AddModulewiseRolePrivilege;
using Internal.Audit.Application.Features.ModulewiseRolePrivilege.Commands.UpdateModulewisePrivilege;
using Internal.Audit.Application.Features.ModulewiseRolePrivilege.Quiries.GetModilewiseRoleByRoleIdList;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Internal.Audit.Api.Controllers
{
    [Route("api/v{version:apiVersion}/ModulewiseRolePrivilege")]
    [ApiController]
    public class ModulewiseRolePrivilegeController : ControllerBase
    {
        private readonly IMediator _mediator;
        public ModulewiseRolePrivilegeController(IMediator madiator)
        {
            _mediator = madiator ?? throw new ArgumentNullException(nameof(madiator));
        }
        [HttpPost("paginatedByRoleId")]
        public async Task<ActionResult<GetModulewiseRolePrivilegeByRoleIdListPagingDTO>> GetList(GetModulewiseRolePrivilegeByRoleIdListQuery modulewiseRoleQuery)
        {
            var roles = await _mediator.Send(modulewiseRoleQuery);
            return Ok(roles);

        }
        [HttpPost]
        public async Task<ActionResult<AddModulewiseRolePrivilegeResponseDTO>> Add(AddModulewiseRolePrivilegeCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpPut]
        public async Task<ActionResult<UpdateModulewiseRolePrivilegeResponseDTO>> Update(UpdateModulewiseRolePrivilegeCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

    }
}

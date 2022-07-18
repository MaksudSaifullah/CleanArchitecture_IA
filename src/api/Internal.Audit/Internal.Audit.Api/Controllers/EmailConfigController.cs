using Internal.Audit.Application.Features.EmailConfig.Commands.AddEmailConfig;
using Internal.Audit.Application.Features.EmailConfig.Commands.DeleteEmailConfig;
using Internal.Audit.Application.Features.EmailConfig.Queries.GetEmailConfigById;
using Internal.Audit.Application.Features.EmailConfig.Queries.GetEmailConfigList;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Internal.Audit.Api.Controllers
{
    [Route("api/v{version:apiVersion}/emailconfig")]
    [ApiController]
    public class EmailConfigController : ControllerBase
    {
        private readonly IMediator _mediator;
        public EmailConfigController(IMediator madiator)
        {
            _mediator = madiator ?? throw new ArgumentNullException(nameof(madiator));
        }


        [HttpPost("paginated")]
        public async Task<ActionResult<EmailConfigListPagingDTO>> GetList(GetEmailConfigListQuery getEmailConfigListQuery)
        {
            var countries = await _mediator.Send(getEmailConfigListQuery);
            return Ok(countries);

        }
        [HttpGet("{Id}")]
        public async Task<ActionResult<GetEmailConfigByIdResponseDTO>> GetById(Guid Id)
        {
            var query = new GetEmailConfigQuery(Id);
            var emailConfig = await _mediator.Send(query);
            return Ok(emailConfig);
        }
        [HttpPost]
        public async Task<ActionResult<AddEmailConfigResponseDTO>> Add(AddEmailConfigCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpDelete("{Id}")]
        public async Task<ActionResult<DeleteEmailConfigResponseDTO>> Delete(Guid Id)
        {
            var command = new DeleteEmailConfigCommand(Id);
            var result = await _mediator.Send(command);
            return Ok(result);
        }

    }
}

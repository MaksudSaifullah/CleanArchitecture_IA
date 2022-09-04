using Internal.Audit.Application.Features.ClosingMeetingMinutes.Commands.AddClosingMeetingMinute;
using Internal.Audit.Application.Features.ClosingMeetingMinutes.Commands.DeleteClosingMeetingMinute;
using Internal.Audit.Application.Features.ClosingMeetingMinutes.Commands.UpdateClosingMeetingMinute;
using Internal.Audit.Application.Features.ClosingMeetingMinutes.Queries.GetClosingMeetingMinuteList;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Internal.Audit.Api.Controllers
{
    [Route("api/v{version:apiVersion}/notificationToAuditee")]
    [ApiController]
    public class NotificationToAuditeeController : ControllerBase
    {
        private readonly IMediator _mediator;
        public NotificationToAuditeeController(IMediator madiator)
        {
            _mediator = madiator ?? throw new ArgumentNullException(nameof(madiator));
        }

        [HttpPost("paginated")]
        public async Task<ActionResult<ClosingMeetingMinuteListPagingDTO>> GetList(GetClosingMeetingMinuteListQuery getClosingMeetingMinuteListQuery)
        {
            var closingMeetingMinutes = await _mediator.Send(getClosingMeetingMinuteListQuery);
            return Ok(closingMeetingMinutes);

        }

        [HttpPost]
        public async Task<ActionResult<AddClosingMeetingMinuteResponseDTO>> Add(AddClosingMeetingMinuteCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpPut]
        public async Task<ActionResult<UpdateClosingMeetingMinuteResponseDTO>> Update(UpdateClosingMeetingMinuteCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpDelete("{Id}")]
        public async Task<ActionResult<DeleteClosingMeetingMinuteResponseDTO>> Delete(Guid Id)
        {
            var command = new DeleteClosingMeetingMinuteCommand(Id);
            var result = await _mediator.Send(command);
            return Ok(result);
        }
    }
}

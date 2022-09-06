using Internal.Audit.Application.Features.ClosingMeetingMinutes.Commands.AddClosingMeetingMinute;
using Internal.Audit.Application.Features.ClosingMeetingMinutes.Commands.DeleteClosingMeetingMinute;
using Internal.Audit.Application.Features.ClosingMeetingMinutes.Commands.UpdateClosingMeetingMinute;
using Internal.Audit.Application.Features.ClosingMeetingMinutes.Queries.GetClosingMeetingMinuteList;
using Internal.Audit.Application.Features.NotificationToAuditees.Commands.AddNotificationToAuditee;
using Internal.Audit.Application.Features.NotificationToAuditees.Commands.DeleteNotificationToAuditee;
using Internal.Audit.Application.Features.NotificationToAuditees.Commands.UpdateNotificationToAuditee;
using Internal.Audit.Application.Features.NotificationToAuditees.Queries.GetNotificationToAuditeeList;
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
        public async Task<ActionResult<NotificationToAuditeeListPagingDTO>> GetList(GetNotificationToAuditeeListQuery getNotificationToAuditeeListQuery)
        {
            var notificationToAuditees = await _mediator.Send(getNotificationToAuditeeListQuery);
            return Ok(notificationToAuditees);

        }

        [HttpPost]
        public async Task<ActionResult<AddNotificationToAuditeeResponseDTO>> Add(AddNotificationToAuditeeCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpPut]
        public async Task<ActionResult<UpdateNotificationToAuditeeResponseDTO>> Update(UpdateNotificationToAuditeeCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpDelete("{Id}")]
        public async Task<ActionResult<DeleteNotificationToAuditeeResponseDTO>> Delete(Guid Id)
        {
            var command = new DeleteNotificationToAuditeeCommand(Id);
            var result = await _mediator.Send(command);
            return Ok(result);
        }
    }
}

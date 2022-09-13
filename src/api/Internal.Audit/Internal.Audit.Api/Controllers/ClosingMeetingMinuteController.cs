using Internal.Audit.Application.Features.ClosingMeetingMinutes.Commands.AddClosingMeetingMinute;
using Internal.Audit.Application.Features.ClosingMeetingMinutes.Commands.DeleteClosingMeetingMinute;
using Internal.Audit.Application.Features.ClosingMeetingMinutes.Commands.UpdateClosingMeetingMinute;
using Internal.Audit.Application.Features.ClosingMeetingMinutes.Queries.GetClosingMeetingMinuteById;
using Internal.Audit.Application.Features.ClosingMeetingMinutes.Queries.GetClosingMeetingMinuteList;
using Internal.Audit.Application.Features.ClosingMeetingMinutes.Queries.GetClosingMeetingMinutesBaseById;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Internal.Audit.Api.Controllers
{
    [Route("api/v{version:apiVersion}/closingmeetingminute")]
    [ApiController]
    public class ClosingMeetingMinuteController : ControllerBase
    {
        private readonly IMediator _mediator;
        public ClosingMeetingMinuteController(IMediator madiator)
        {
            _mediator = madiator ?? throw new ArgumentNullException(nameof(madiator));
        }

        [HttpPost("paginated")]
        public async Task<ActionResult<ClosingMeetingMinuteListPagingDTO>> GetList(GetClosingMeetingMinuteListQuery getClosingMeetingMinuteListQuery)
        {
            var closingMeetingMinutes = await _mediator.Send(getClosingMeetingMinuteListQuery);
            return Ok(closingMeetingMinutes);

        }
        //
        [HttpGet("{Id}")]
        public async Task<ActionResult<ClosingMeetingMinuteByIdDTO>> GetById(Guid Id)
        {
            var query = new GetClosingMeetingMinuteQuery(Id);
            var closingMeetingMinutes = await _mediator.Send(query);
            return Ok(closingMeetingMinutes);

        }
        [HttpGet("BaseId")]
        public async Task<ActionResult<GetClosingMeetingMinutesResponseDTO>> GetByBaseId(Guid BaseId)
        {
            var query = new GetClosingMeetingMinutesBaseByIdQuery(BaseId);
            var closingMeetingMinutes = await _mediator.Send(query);
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

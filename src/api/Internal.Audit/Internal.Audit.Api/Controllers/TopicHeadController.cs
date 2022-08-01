using Internal.Audit.Application.Features.TopicHeads.Commands.AddTopicHead;
using Internal.Audit.Application.Features.TopicHeads.Commands.DeleteTopicHead;
using Internal.Audit.Application.Features.TopicHeads.Commands.UpdateTopicHead;
using Internal.Audit.Application.Features.TopicHeads.Queries.GetTopicHeadByFilter;
using Internal.Audit.Application.Features.TopicHeads.Queries.GetTopicHeadById;
using Internal.Audit.Application.Features.TopicHeads.Queries.GetTopicHeadList;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Internal.Audit.Api.Controllers
{
    [Route("api/v{version:apiVersion}/topicHead")]
    [ApiController]
    public class TopicHeadController : ControllerBase
    {
        private readonly IMediator _mediator;
        public TopicHeadController(IMediator madiator)
        {
            _mediator = madiator ?? throw new ArgumentNullException(nameof(madiator));
        }

        [HttpPost("paginated")]
        public async Task<ActionResult<TopicHeadListPagingDTO>> GetList(GetTopicHeadListQuery getTopicHeadListQuery)
        {
            var topicHeadList = await _mediator.Send(getTopicHeadListQuery);
            return Ok(topicHeadList);
        }

        [HttpGet("id")]
        public async Task<ActionResult<TopicHeadByIdDTO>> GetById(Guid Id)
        {
            var query = new GetTopicHeadByIdQuery(Id);
            var topicHead = await _mediator.Send(query);
            return Ok(topicHead);
        }

        [HttpPost("filter")]
        public async Task<ActionResult<IEnumerable<GetTopicHeadByFilterResponseDTO>>> GetByFilter(GetTopicHeadFilterDTO Filter)
        {
            var query = new GetTopicHeadByFilterQuery(Filter);
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<AddTopicHeadResponseDTO>> Add(AddTopicHeadCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpPut]
        public async Task<ActionResult<UpdateTopicHeadResponseDTO>> Update(UpdateTopicHeadCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpDelete("id")]
        public async Task<ActionResult<DeleteTopicHeadResponseDTO>> Delete(Guid Id)
        {
            var command = new DeleteTopicHeadCommand(Id);
            var result = await _mediator.Send(command);
            return Ok(result);
        }

    }

}


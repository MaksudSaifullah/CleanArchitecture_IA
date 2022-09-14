using Internal.Audit.Application.Features.Checklists.Commands.AddChecklist;
using Internal.Audit.Application.Features.Checklists.Commands.DeleteChecklist;
using Internal.Audit.Application.Features.Checklists.Commands.UpdateChecklist;
using Internal.Audit.Application.Features.Checklists.Queries.GetChecklistList;
using Internal.Audit.Application.Features.Checklists.Queries.GetChecklistListBaseById;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Internal.Audit.Api.Controllers
{
    
    [Route("api/v{version:apiVersion}/checklist")]
    [ApiController]
    public class ChecklistController : ControllerBase
    {
        private readonly IMediator _mediator;
        public ChecklistController(IMediator madiator)
        {
            _mediator = madiator ?? throw new ArgumentNullException(nameof(madiator));
        }

        [HttpPost("paginated")]
        public async Task<ActionResult<ChecklistListPagingDTO>> GetList(GetChecklistListQuery getChecklistListQuery)
        {
            var checklist = await _mediator.Send(getChecklistListQuery);
            return Ok(checklist);

        }
        
        [HttpGet("BaseId")]
        public async Task<ActionResult<GetChecklistBaseResponseDTO>> GetByBaseId(Guid BaseId)
        {
            var query = new GetChecklistBaseByIdQuery(BaseId);
            var checklist = await _mediator.Send(query);
            return Ok(checklist);

        }

        [HttpPost]
        public async Task<ActionResult<AddChecklistResponseDTO>> Add(AddChecklistCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpPut]
        public async Task<ActionResult<UpdateChecklistResponseDTO>> Update(UpdateChecklistCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpDelete("{Id}")]
        public async Task<ActionResult<DeleteChecklistResponseDTO>> Delete(Guid Id)
        {
            var command = new DeleteChecklistCommand(Id);
            var result = await _mediator.Send(command);
            return Ok(result);
        }
    }
}

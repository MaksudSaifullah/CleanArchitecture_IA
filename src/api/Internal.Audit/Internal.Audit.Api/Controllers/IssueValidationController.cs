using Internal.Audit.Application.Features.IssueValidations.Commands.AddIssueValidationCommand;
using Internal.Audit.Application.Features.IssueValidations.Commands.DeleteIssueValidationCommand;
using Internal.Audit.Application.Features.IssueValidations.Commands.UpdateIssueValidationCommand;
using Internal.Audit.Application.Features.IssueValidations.Queries.GetIssueValidationByIssueId;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Internal.Audit.Api.Controllers
{
    [Route("api/v{version:apiVersion}/issuevalidation")]
    [ApiController]
    public class IssueValidationController : ControllerBase
    {
        private readonly IMediator _mediator;
        public IssueValidationController(IMediator madiator)
        {
            _mediator = madiator ?? throw new ArgumentNullException(nameof(madiator));
        }


        [HttpPost]
        public async Task<ActionResult<AddIssueValidationCOmmandResponseDTO>> Add(AddIssueValidationCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }
        [HttpPut]
        public async Task<ActionResult<UpdateIssueValdiationCommandResponseDTO>> Update(UpdateIssueValidationCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }
        [HttpDelete("id")]
        public async Task<ActionResult<DeleteIssueValidationCommandResponseDTO>> Delete(Guid Id)
        {
            var command = new DeleteIssueValidationCommand(Id);
            var result = await _mediator.Send(command);
            return Ok(result);
        }
        [HttpGet("GetByIssueId")]
        public async Task<ActionResult<GetIssueValidationByIssueIdQueryResponseDTO>> GetByIssueId(Guid Id)
        {
            var command = new GetIssueValidationByIssueIdQuery(Id);
            var result = await _mediator.Send(command);
            return Ok(result);
        }

    }
}

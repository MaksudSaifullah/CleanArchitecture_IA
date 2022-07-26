using MediatR;
using Microsoft.AspNetCore.Mvc;
using Internal.Audit.Application.Features.AuditFrequencies.Queries.GetAuditFrequencyList;
using Internal.Audit.Application.Features.AuditFrequencies.Queries.GetAuditFrequencyById;
using Internal.Audit.Application.Features.AuditFrequencies.Commands.AddAuditFrequency;
using Internal.Audit.Application.Features.AuditFrequencies.Commands.UpdateAuditFrequency;
using Internal.Audit.Application.Features.AuditFrequencies.Commands.DeleteAuditFrequency;

namespace Internal.Audit.Api.Controllers
{
    [Route("api/v{version:apiVersion}/auditfrequency")]
    [ApiController]
    public class AuditFrequencyController : ControllerBase
    {
        private readonly IMediator _mediator;
        public AuditFrequencyController(IMediator madiator)
        {
            _mediator = madiator ?? throw new ArgumentNullException(nameof(madiator));
        }

        [HttpPost("paginated")]
        public async Task<ActionResult<AuditFrequencyListPagingDTO>> GetList(GetAuditFrequencyListQuery getAuditFrequencyListQuery)
        {
            var auditFrequency = await _mediator.Send(getAuditFrequencyListQuery);
            return Ok(auditFrequency);

        }

        [HttpGet("{Id}")]
        public async Task<ActionResult<AuditFrequencyByIdDTO>> GetById(Guid Id)
        {
            var query = new GetAuditFrequencyQuery(Id);
            var auditFrequencies = await _mediator.Send(query);
            return Ok(auditFrequencies);

        }

        [HttpPost]
        public async Task<ActionResult<AddAuditFrequencyResponseDTO>> Add(AddAuditFrequencyCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpPut]
        public async Task<ActionResult<UpdateAuditFrequencyResponseDTO>> Update(UpdateAuditFrequencyCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpDelete("{Id}")]
        public async Task<ActionResult<DeleteAuditFrequencyResponseDTO>> Delete(Guid Id)
        {
            var command = new DeleteAuditFrequencyCommand(Id);
            var result = await _mediator.Send(command);
            return Ok(result);
        }
    }
}

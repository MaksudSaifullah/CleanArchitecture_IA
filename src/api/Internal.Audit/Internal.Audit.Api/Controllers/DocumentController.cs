using Internal.Audit.Application.Features.Documents.Commands.AddDocumentCommand;
using Internal.Audit.Application.Features.Documents.Commands.DeleteDocumentCommand;
using Internal.Audit.Application.Features.Documents.Commands.UpdateDocumentCommand;
using Internal.Audit.Application.Features.Documents.Queries.GetByDocumentId;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.IO;

namespace Internal.Audit.Api.Controllers
{
    [Route("api/v{version:apiVersion}/Document")]
    [ApiController]
    public class DocumentController : ControllerBase
    {
        private readonly IMediator _mediator;
        public DocumentController(IMediator madiator)
        {
            _mediator = madiator ?? throw new ArgumentNullException(nameof(madiator));
        }
        [HttpPost]
        public async Task<ActionResult<AddDocumentCommandResponseDTO>> Add([FromForm] AddDocumentCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }
        [HttpPut]
        public async Task<ActionResult<UpdateDocumentCommandDTO>> Update([FromForm] UpdateDocumentCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }
        [HttpDelete]
        public async Task<ActionResult<DeleteDocumentCommandDTO>> Delete(Guid Id)
        {
            var command = new DeleteDocumentCommand(Id);
            var result = await _mediator.Send(command);
           
            return Ok(result);
        }
        [HttpGet]
        public async Task<ActionResult<GetByDocumentIdResponseDTO>> GetById(Guid Id)
        {
            var query = new GetByDocumentQuery(Id);
            var doc = await _mediator.Send(query);
            return Ok(doc);

        }
        
        [HttpGet("get-file-stream")]
        public async Task<IActionResult> File(Guid Id)
        {
            var query = new GetByDocumentQuery(Id);
            var doc = await _mediator.Send(query);
            string contentType = "application/octet-stream";

            var bytes = await System.IO.File.ReadAllBytesAsync(Path.Combine(doc.Path));
            return File(bytes, contentType, doc.Name+doc.Format);
     
        }
    }
}

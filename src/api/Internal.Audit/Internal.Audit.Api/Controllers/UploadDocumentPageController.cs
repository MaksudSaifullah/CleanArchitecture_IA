using Internal.Audit.Application.Features.UploadDocuments.Commands.AddUploadDocument;
using Internal.Audit.Application.Features.UploadDocuments.Commands.DeleteUploadDocument;
using Internal.Audit.Application.Features.UploadDocuments.Queries.GerttUploadedDocumentListPagingFormat;
using Internal.Audit.Application.Features.UploadDocuments.Queries.GetUploadedDocumentListByRoled;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Internal.Audit.Api.Controllers
{
    [Route("api/v{version:apiVersion}/UploadDocumentPage")]
    [ApiController]
    public class UploadDocumentPageController : ControllerBase
    {
        private readonly IMediator _mediator;
        public UploadDocumentPageController(IMediator madiator)
        {
            _mediator = madiator ?? throw new ArgumentNullException(nameof(madiator));
        }

        [HttpPost]
        public async Task<ActionResult<AddUploadDocumentResponseDTO>> Add(AddUploadDocumentCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpDelete("id")]
        public async Task<ActionResult<DeleteUploadDocumentResponseDTO>> Delete(Guid Id)
        {
            var command = new DeleteUploadDocumentCommand(Id);
            var result = await _mediator.Send(command);
            return Ok(result);
        }
        [HttpPost("roleid")]
        public async Task<ActionResult<GerttUploadedDocumentListPagingFormatDTO>> Get(GetUploadDocumentListPagingFormatQuery query)
        {
            var result = await _mediator.Send(query);
            return Ok(result);
        }

    }
}

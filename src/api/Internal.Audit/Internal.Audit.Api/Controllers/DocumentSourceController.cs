using Internal.Audit.Application.Features.DocumentSources.Queries.GetAllDocumentSource;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Internal.Audit.Api.Controllers
{
    [Route("api/v{version:apiVersion}/DocumentSource")]
    [ApiController]
    public class DocumentSourceController : ControllerBase
    {
        private readonly IMediator _mediator;
        public DocumentSourceController(IMediator madiator)
        {
            _mediator = madiator ?? throw new ArgumentNullException(nameof(madiator));
        }
        [HttpGet]
        public async Task<ActionResult<GetAllDocumentSourceDTO>> Get()
        {
            var query = new GetAllDocumentSourceQuery();
            var result = await _mediator.Send(query);
            return Ok(result);
        }
    }
}
